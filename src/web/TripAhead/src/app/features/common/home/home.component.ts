import {Component, OnInit} from '@angular/core';
import {Router} from "@angular/router";
import {AuthState} from "../../../core/store/auth/auth.reducer";
import {Store} from "@ngrx/store";
import {Observable} from "rxjs";
import {initAuth, loadUser, logout} from "../../../core/store/auth/auth.actions";
import {selectUserProfile} from "../../../core/store/auth/auth.selectors";
import {CommonModule} from "@angular/common";
import {User} from "../../../../types/user";
import {NavbarComponent} from "./navbar/navbar.component";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, NavbarComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {
  user$: Observable<User | null> | undefined;
  loading$: Observable<boolean> | undefined;
  error$: Observable<any> | undefined;
constructor(private router: Router) {
  // this.authState.dispatch(loadUser());
  //
  // this.user$ = this.authState.select(selectUserProfile);
}

  ngOnInit(): void {
    // this.user$ = this.authState.select(selectUserProfile);
  }

  // login(): void {
  //   this.authState.dispatch(initAuth());
  // }
  //
  // logout(): void {
  //   this.authState.dispatch(logout());
  // }
  //
  // navigateSecured(): void {
  //       this.router.navigate(['secure']);
  // }
  //
  // navigateNotSecured(): void {
  //   this.router.navigate(['not-secure']);
  // }
}
