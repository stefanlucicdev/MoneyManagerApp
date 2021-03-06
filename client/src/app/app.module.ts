import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { GetStartedComponent } from './get-started/get-started.component';
import { UserOverviewComponent } from './user-overview/user-overview.component';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { TextInputComponent } from './_forms/text-input/text-input.component';
import { DateInputComponent } from './_forms/date-input/date-input.component';
import { SharedModule } from './_modules/shared.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AddMoneyAccountComponent } from './modals/add-money-account/add-money-account.component';
import { MoneyAccountComponent } from './money-account/money-account.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    GetStartedComponent,
    UserOverviewComponent,
    TextInputComponent,
    DateInputComponent,
    AddMoneyAccountComponent,
    MoneyAccountComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    SharedModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }
