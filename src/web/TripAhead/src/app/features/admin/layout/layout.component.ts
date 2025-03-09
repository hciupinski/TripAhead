import { Component, ViewChild } from '@angular/core';
import { DrawerModule } from 'primeng/drawer';
import { ButtonModule } from 'primeng/button';
import { AvatarModule } from 'primeng/avatar';
import { Drawer } from 'primeng/drawer';
import { RouterOutlet} from "@angular/router";
import {SidebarComponent} from "../components/sidebar/sidebar.component";

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  standalone: true,
  imports: [DrawerModule, ButtonModule, AvatarModule, RouterOutlet, SidebarComponent]
})
export class LayoutComponent {
  @ViewChild('drawerRef') drawerRef!: Drawer;

  visible: boolean = true;
}
