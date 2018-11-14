import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { NgxEchartsModule } from 'ngx-echarts';
import { AppComponent } from './app.component';
import { ValueComponent } from './value/value.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { NavComponent } from './nav/nav.component';
import { AuthService } from './_services/auth.service';
import { ErrorInterceptorProvider } from './_services/error.inteceptor';
import { AlertifyService } from './_services/alertify.service';
import { MessagesComponent } from './messages/messages.component';
import { appRoutes } from './routes';
import { AuthGuard } from './_guards/auth.guard';



@NgModule({
   declarations: [
      AppComponent,
      ValueComponent,
      HomeComponent,
      RegisterComponent,
      LoginComponent,
      NavComponent,
      MessagesComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      NgxEchartsModule,
      FormsModule,
      RouterModule.forRoot(appRoutes)
   ],
   providers: [
      AuthService,
      ErrorInterceptorProvider,
      AlertifyService,
      AuthGuard
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
