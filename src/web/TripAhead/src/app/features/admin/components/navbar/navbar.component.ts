import { Component } from '@angular/core';
import {BadgeModule} from "primeng/badge";
import {MenubarModule} from "primeng/menubar";
import {CommonModule} from "@angular/common";
import {AvatarModule} from "primeng/avatar";
import {MenuItem} from "primeng/api";
import {RippleModule} from "primeng/ripple";

@Component({
    selector: 'app-navbar',
    imports: [CommonModule, BadgeModule, MenubarModule, AvatarModule, RippleModule],
    templateUrl: './navbar.component.html',
    styleUrl: './navbar.component.scss'
})
export class NavbarComponent {

  items: MenuItem[] | undefined;

  ngOnInit() {
    this.items = [
      {
        label: 'Home',
        icon: 'pi pi-home',
      },
      {
        label: 'Projects',
        icon: 'pi pi-search',
        badge: '3',
        items: [
          {
            label: 'Core',
            icon: 'pi pi-bolt',
            shortcut: '⌘+S',
          },
          {
            label: 'Blocks',
            icon: 'pi pi-server',
            shortcut: '⌘+B',
          },
          {
            separator: true,
          },
          {
            label: 'UI Kit',
            icon: 'pi pi-pencil',
            shortcut: '⌘+U',
          },
        ],
      },
    ];
  }
}
