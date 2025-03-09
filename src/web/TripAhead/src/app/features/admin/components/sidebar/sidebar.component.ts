import { Component } from '@angular/core';
import {MessageService} from "primeng/api";
import {RouterLink, RouterOutlet} from "@angular/router";
import {AvatarModule} from "primeng/avatar";
import {DrawerModule} from "primeng/drawer";
import {Ripple} from "primeng/ripple";
import {StyleClass} from "primeng/styleclass";
import {ButtonModule} from "primeng/button";

@Component({
  selector: 'app-sidebar',
  imports: [DrawerModule, ButtonModule, Ripple, AvatarModule, StyleClass, RouterLink],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.scss',
  providers: [MessageService]
})
export class SidebarComponent {
  visible: boolean = true;
}
