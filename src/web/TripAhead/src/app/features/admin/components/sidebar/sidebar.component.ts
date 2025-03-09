import { Component } from '@angular/core';
import {PanelMenu} from "primeng/panelmenu";
import {MenuItem, MessageService} from "primeng/api";
import {Router, RouterModule} from "@angular/router";

@Component({
  selector: 'app-sidebar',
  imports: [PanelMenu, RouterModule],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.scss',
  providers: [MessageService]
})
export class SidebarComponent {
  items: MenuItem[] | undefined;

  constructor(private router: Router) {}

  ngOnInit() {
    this.items = [
      {
        label: 'Router',
        icon: 'pi pi-palette',
        items: [
          {
            label: 'Installation',
            icon: 'pi pi-eraser',
            route: '/installation'
          },
          {
            label: 'Configuration',
            icon: 'pi pi-heart',
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
            icon: 'pi pi-star',
            url: 'https://angular.io/'
          },
          {
            label: 'Vite.js',
            icon: 'pi pi-bookmark',
            url: 'https://vitejs.dev/'
          }
        ]
      }
    ];
  }
}
