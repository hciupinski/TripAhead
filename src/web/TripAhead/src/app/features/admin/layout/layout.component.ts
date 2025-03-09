import { Component } from '@angular/core';
import {NavbarComponent} from "../components/navbar/navbar.component";
import {SidebarComponent} from "../components/sidebar/sidebar.component";
import {RouterOutlet} from "@angular/router";

@Component({
    selector: 'app-layout',
  imports: [
    NavbarComponent,
    SidebarComponent,
    RouterOutlet
  ],
    templateUrl: './layout.component.html',
    styleUrl: './layout.component.scss'
})
export class LayoutComponent {

}
