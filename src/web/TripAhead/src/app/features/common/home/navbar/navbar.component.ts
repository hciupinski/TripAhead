import {Component, effect, inject, OnInit} from '@angular/core';
import {MenubarModule} from "primeng/menubar";
import {Router, RouterModule} from "@angular/router";
import {MenuItem} from "primeng/api";
import {CommonModule} from "@angular/common";
import Keycloak from "keycloak-js";
import {KEYCLOAK_EVENT_SIGNAL, KeycloakEventType, ReadyArgs, typeEventArgs} from "keycloak-angular";

@Component({
    selector: 'app-navbar',
    imports: [MenubarModule, CommonModule, RouterModule],
    templateUrl: './navbar.component.html',
    styleUrl: './navbar.component.scss'
})
export class NavbarComponent implements OnInit {
  items: MenuItem[] | undefined;
  authenticated = false;

  constructor(private router: Router, private readonly keycloak: Keycloak) {
    const keycloakSignal = inject(KEYCLOAK_EVENT_SIGNAL);

    effect(() => {
      const keycloakEvent = keycloakSignal();

      if (keycloakEvent.type === KeycloakEventType.Ready) {
        this.authenticated = typeEventArgs<ReadyArgs>(keycloakEvent.args);
      }

      if (keycloakEvent.type === KeycloakEventType.AuthLogout) {
        this.authenticated = false;
      }
    });
  }
    ngOnInit(): void {
      this.items = [
        {
          label: 'Admin panel',
          icon: 'pi pi-palette',
          command: () => {
            this.router.navigate(['/admin']);
          }
        },
        {
          label: 'Login',
          icon: 'pi pi-link',
          visible: !this.authenticated
        },
        {
          label: 'Logout',
          icon: 'pi pi-home',
          visible: this.authenticated
        }
      ];
    }

}
