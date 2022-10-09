import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';;
import { FormEmpleadosComponent } from './modules/form-empleados/form-empleados.component'

////////
import { FormGroup, FormControl, Validators } from "@angular/forms";
import {  ReactiveFormsModule } from '@angular/forms';
import { AgGridModule } from 'ag-grid-angular';
import{RinkuService} from '../../src/app/services/rinku.service';
import{Empleados,TipoEmpleados,Movimientos} from '../../src/app/rinkuClass/empleados';;
import { FormMovimientosComponent } from './modules/form-movimientos/form-movimientos.component'
;
import { FormReportComponent } from './modules/form-report/form-report.component'
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    FormEmpleadosComponent,
    FormMovimientosComponent
,
    FormReportComponent    ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
  
    ReactiveFormsModule,
    AgGridModule.withComponents([]),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      {path:'FormEmpleado',component:FormEmpleadosComponent},
      {path:'FormMovimientos',component:FormMovimientosComponent},
      {path:'FormReport',component:FormReportComponent},
      
    ])
  ],
  providers: [ReactiveFormsModule,RinkuService ,Empleados,TipoEmpleados,Movimientos],
  
  bootstrap: [AppComponent]
})
export class AppModule { }
