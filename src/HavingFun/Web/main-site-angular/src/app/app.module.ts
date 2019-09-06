import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { TokenInterceptor } from './infrastructure/token.interceptor';
import { UsersListComponent } from './features/users/users-list/users-list.component';
import { LoginComponent } from './features/login/login.component';

import {ButtonModule} from 'primeng/button';
import { AuthGuard } from './infrastructure/auth.guard';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    UsersListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ButtonModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    },
    AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
