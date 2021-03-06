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
import {ProgressSpinnerModule} from 'primeng/progressspinner';
import {TreeModule} from 'primeng/tree';

import { AuthGuard } from './infrastructure/auth.guard';
import { UnauthorizedResponseInterceptor } from './infrastructure/unauthorized-response.interceptor';
import { InsufficientPermissionsComponent } from './features/error-pages/insufficient-permissions/insufficient-permissions.component';
import { RegisterUserComponent } from './features/users/register-user/register-user.component';
import { UserRegisteredActivationRequiredComponent } from './features/users/user-registered-activation-required/user-registered-activation-required.component';
import { ProductsListComponent } from './features/products/products-list/products-list.component';
import { ProductViewComponent } from './features/products/product-view/product-view.component';
import { ProductsGridComponent } from './features/products/products-grid/products-grid.component';
import { ProductsFilterComponent } from './features/products/products-filter/products-filter.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    UsersListComponent,
    InsufficientPermissionsComponent,
    RegisterUserComponent,
    UserRegisteredActivationRequiredComponent,
    ProductsListComponent,
    ProductViewComponent,
    ProductsGridComponent,
    ProductsFilterComponent
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
    PaginatorModule,
    ProgressSpinnerModule,
    TreeModule
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
