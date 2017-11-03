import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { CookieModule } from 'ngx-cookie';

import { AppComponent } from './app.component';
import { AppRoutes } from './app.routes';

import {
  DashboardComponent,
  LoginComponent,
} from './main';

import {
  NavbarComponent,
} from './shared';

@NgModule({
  declarations: [
    AppComponent,

    NavbarComponent,

    DashboardComponent,
    LoginComponent,
  ],
  imports: [
    AppRoutes,

    HttpModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,

    BrowserModule,
    CookieModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
