import {Component, OnInit} from '@angular/core';
import {MenubarModule} from "primeng/menubar";
import {Router, RouterModule} from "@angular/router";
import {MenuItem} from "primeng/api";
import {CommonModule} from "@angular/common";

@Component({
    selector: 'app-navbar',
    imports: [MenubarModule, CommonModule, RouterModule],
    templateUrl: './navbar.component.html',
    styleUrl: './navbar.component.scss'
})
export class NavbarComponent implements OnInit {
  items: MenuItem[] | undefined;

  constructor(private router: Router) {
  }
    ngOnInit(): void {
      this.items = [
        {
          label: 'Router',
          icon: 'pi pi-palette',
          items: [
            {
              label: 'Installation',
              route: '/installation'
            },
            {
              label: 'Configuration',
              route: '/configuration'
            }
          ]
        },
        {
          label: 'Programmatic',
          icon: 'pi pi-link',
          command: () => {
            this.router.navigate(['/installation']);
          }
        },
        {
          label: 'External',
          icon: 'pi pi-home',
          items: [
            {
              label: 'Angular',
              url: 'https://angular.io/'
            },
            {
              label: 'Vite.js',
              url: 'https://vitejs.dev/'
            }
          ]
        }
      ];
    }

}
