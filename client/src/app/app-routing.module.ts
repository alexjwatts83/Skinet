import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestErrorComponent, ServerErrorComponent, NotFoundComponent } from './core';
import { HomeComponent } from './home';

const routes: Routes = [
  {path: '', component: HomeComponent, data: {breadcrumb: 'Home'}},
  {path: 'test-error', component: TestErrorComponent, data: {breadcrumb: 'Test Errors'}},
  {path: 'server-error', component: ServerErrorComponent, data: {breadcrumb: 'Server Error'}},
  {path: 'not-found', component: NotFoundComponent, data: {breadcrumb: 'Found, it was not'}},
  {path: 'shop', loadChildren: () => import('./shop/shop.module').then(mod => mod.ShopModule), data: {breadcrumb: 'Shop'}} ,
  {path: 'basket', loadChildren: () => import('./basket/basket.module').then(mod => mod.BasketModule), data: {breadcrumb: 'Basket'}} ,
  {path: 'checkout', loadChildren: () => import('./checkout/checkout.module').then(mod => mod.CheckoutModule), data: {breadcrumb: 'Checkout'}} ,
  {path: 'account', loadChildren: () => import('./account/account.module').then(mod => mod.AccountModule), data: {breadcrumb: { skip: true }}} ,
  {path: '**',  redirectTo : 'not-found', pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
