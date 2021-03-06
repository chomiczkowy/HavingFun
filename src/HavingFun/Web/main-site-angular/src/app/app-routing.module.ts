import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UsersListComponent } from './features/users/users-list/users-list.component';
import { LoginComponent } from './features/login/login.component';
import { AuthGuard } from './infrastructure/auth.guard';
import { InsufficientPermissionsComponent } from './features/error-pages/insufficient-permissions/insufficient-permissions.component';
import { UserRegisteredActivationRequiredComponent } from './features/users/user-registered-activation-required/user-registered-activation-required.component';
import { RegisterUserComponent } from './features/users/register-user/register-user.component';
import { ProductsListComponent } from './features/products/products-list/products-list.component';
import { ProductViewComponent } from './features/products/product-view/product-view.component';

const routes: Routes = [
  {
    path:'products/list',
    component: ProductsListComponent
  },
  {
    path:'products/:productId',
    component: ProductViewComponent
  },
  {
    path:'user/list',
    component: UsersListComponent,
    canActivate: [AuthGuard]
  },
  {
    path:'login',
    component: LoginComponent
  },
  {
    path:'user/activationRequired',
    component: UserRegisteredActivationRequiredComponent
  },
  {
    path:'register',
    component: RegisterUserComponent
  },
  {
    path:'error/insufficient-permissions',
    component: InsufficientPermissionsComponent
  },
  { path: '',
    redirectTo: '/products/list',
    pathMatch: 'full',
    canActivate: [AuthGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
