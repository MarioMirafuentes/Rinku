
import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import{Empleados,Movimientos,Nomina,TipoEmpleados} from '../rinkuClass/empleados';


@Injectable({
  providedIn: 'root'
})
export class RinkuService {
  urlBase: string;
  constructor(private http: HttpClient, @Inject("BASE_URL") url: string) {
    this.urlBase = url;
  }

  public SetSaveEmpleado(empleado:Empleados){
  
    var url = this.urlBase + "Api/SetNewEmpleado/";
   
    return this.http.post(url,empleado);

  }
  public GetAllEmpleado():Observable<any>{
  
    var url = this.urlBase + "Api/GetAllEmpleados/";
    return this.http.get(url);

  }  
  public GetEmpleado(cv:number):Observable<any>{
  
    var url = this.urlBase + "Api/GetEmpleado/";
    return this.http.get(url+cv);

  }  
  public GetRepet(num:string ):Observable<any>{

    var url = this.urlBase + "Api/GetRepet/";
    return this.http.get(url+num);

  }  
  public GetTipoEmpleado():Observable<any>{

    var url = this.urlBase + "Api/GetTipoEmpleado/";
    return this.http.get(url);

  }  
  public GetAllPeriodos():Observable<any>{

    var url = this.urlBase + "Api/GetAllPeriodos/";
    return this.http.get(url);

  }  

  public SetNewMoviemiento(movimiento:Movimientos):Observable<Blob>{
  
    var url = this.urlBase + "Api/SetNewMoviemiento/";
 
    return this.http.post(url,movimiento,{responseType:'blob'});

  }

  public QueryNominas():Observable<any>{

    var url = this.urlBase + "Api/QueryNominas/";
    return this.http.get(url);

  }  

}




