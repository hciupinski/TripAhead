// Ensure Angular 19 compatibility
// Install dependencies: npm install three @types/three

import { Component, ElementRef, NgZone, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import * as THREE from 'three';
import {CommonModule} from "@angular/common";
import {RouterLink} from "@angular/router";

@Component({
  selector: 'app-3d-room',
  imports: [CommonModule, RouterLink],
  templateUrl: './three-room.component.html',
  styleUrl: './three-room.component.scss'
})
export class ThreeRoomComponent implements OnInit, AfterViewInit, OnDestroy {
  @ViewChild('canvas', { static: true }) canvasRef!: ElementRef<HTMLCanvasElement>;
  private scene!: THREE.Scene;
  private camera!: THREE.PerspectiveCamera;
  private renderer!: THREE.WebGLRenderer;
  private elements: THREE.Mesh[] = [];
  private animationFrameId!: number;
  private clock = new THREE.Clock();

  constructor(private ngZone: NgZone) {}

  ngOnInit() {
    window.addEventListener('resize', this.onWindowResize);
  }

  ngAfterViewInit() {
    this.ngZone.runOutsideAngular(() => {
      this.initScene();
      this.animate();
    });
  }

  private initScene() {
    const canvas = this.canvasRef.nativeElement;
    this.scene = new THREE.Scene();
    this.scene.background = new THREE.Color(0xF5F5DC); // Light beige background

    this.camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);
    this.camera.position.set(0, 2, 5);

    this.renderer = new THREE.WebGLRenderer({ canvas, alpha: true });
    this.renderer.setSize(window.innerWidth, window.innerHeight);

    // Soft shadow effect
    this.renderer.shadowMap.enabled = true;
    this.renderer.shadowMap.type = THREE.PCFSoftShadowMap;

    // Room walls
    const roomMaterial = new THREE.MeshStandardMaterial({ color: 0xFAEBD7, side: THREE.BackSide }); // Light beige walls
    const room = new THREE.Mesh(new THREE.BoxGeometry(10, 5, 10), roomMaterial);
    this.scene.add(room);

    // Rotating elements
    const geometry = new THREE.SphereGeometry(0.3);
    const material = new THREE.MeshStandardMaterial({ color: 0xff0000 });
    for (let i = 0; i < 3; i++) {
      const element = new THREE.Mesh(geometry, material);
      element.castShadow = true;
      this.scene.add(element);
      this.elements.push(element);
    }

    // Lights for brightening the scene
    const ambientLight = new THREE.AmbientLight(0xFFFFFF, 1.2); // Strong ambient light
    this.scene.add(ambientLight);

    const directionalLight = new THREE.DirectionalLight(0x008000, 1.5); // Dark green-tinted shadows
    directionalLight.position.set(5, 5, 5);
    directionalLight.castShadow = true;
    this.scene.add(directionalLight);
  }

  private animate = () => {
    this.animationFrameId = requestAnimationFrame(this.animate);
    const time = this.clock.getElapsedTime();
    const height = 2; // Vertical movement range
    const radius = 3;

    for (let i = 0; i < this.elements.length; i++) {
      const angle = time + (i * (Math.PI * 2)) / 3;
      this.elements[i].position.set(Math.cos(angle) * radius, Math.sin(angle) * height, Math.sin(angle) * radius);
    }

    this.renderer.render(this.scene, this.camera);
  };

  private onWindowResize = () => {
    this.camera.aspect = window.innerWidth / window.innerHeight;
    this.camera.updateProjectionMatrix();
    this.renderer.setSize(window.innerWidth, window.innerHeight);
  };

  ngOnDestroy() {
    cancelAnimationFrame(this.animationFrameId);
    window.removeEventListener('resize', this.onWindowResize);
  }
}
