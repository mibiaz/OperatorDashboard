import {Routes} from '@angular/router';
import {HomeComponent} from './home/home.component';
import {MessagesComponent} from './messages/messages.component';
import {LoginComponent} from './login/login.component';
import { AuthGuard } from './_guards/auth.guard';

export const appRoutes: Routes = [
    {path: 'login', component: LoginComponent},
    {path: 'home', component: HomeComponent, canActivate: [AuthGuard]},
    {path: 'messages', component: MessagesComponent, canActivate: [AuthGuard]},
    {path: '**', redirectTo: '', pathMatch: 'full'},
];
