import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { TokenInterceptor } from './infrastructure/token.interceptor';
import { UsersListComponent } from './features/users/users-list/users-list.component';
import { LoginComponent } from './features/login/login.component';

import {ButtonModule} from 'primeng/button';
import {TableModule} from 'primeng/table';
import {InputTextModule} from 'primeng/inputtext';
import {PaginatorModule} from 'primeng/paginator';

import { AuthGuard } from './infrastructure/auth.guard';
import { UnauthorizedResponseInterceptor } from './infrastructure/unauthorized-response.interceptor';
import { InsufficientPermissionsComponent } from './features/error-pages/insufficient-permissions/insufficient-permissions.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    UsersListComponent,
    InsufficientPermissionsComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,


    //PrimeNg modules
    ButtonModule,
    TableModule,
    InputTextModule,
    PaginatorModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: UnauthorizedResponseInterceptor,
      multi: true
    },
    AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
