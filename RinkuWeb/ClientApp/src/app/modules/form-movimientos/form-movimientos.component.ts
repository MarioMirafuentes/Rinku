import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, ReactiveFormsModule } from "@angular/forms";
import { ColDef, GridApi, } from 'ag-grid-community';
import { RinkuService } from '../../services/rinku.service';
import { Empleados, TipoEmpleados, Movimientos, Periodos } from '../../rinkuClass/empleados';


@Component({
  selector: 'app-form-movimientos',
  templateUrl: './form-movimientos.component.html',
  styleUrls: ['./form-movimientos.component.css']
})
export class FormMovimientosComponent implements OnInit {
  FormMovimientos: FormGroup;
  FormNominas: FormGroup;
  ListEmpleados: Array<Empleados>
  TiposEmpleado: Array<TipoEmpleados>
  Periodos: Array<Periodos>

  constructor(
    private rinkuService: RinkuService,
    private empleado: Empleados,
    private tipoEmpleado: TipoEmpleados,
    private movimientos: Movimientos
  ) {
    this.FormMovimientos = new FormGroup({
      CvMovimiento: new FormControl(0),
      NumEntregas: new FormControl(0,),
      CvTipoEmpleado: new FormControl(0,),
      CvEmpleado: new FormControl(0,),
      CvPeriodo: new FormControl(0,),
      Descripcion: new FormControl("",),
      Hdes: new FormControl(0,),

    })
  }

  ngOnInit() {
    this.OnLoadModule();
  }

  OnLoadModule() {
    this.rinkuService.GetTipoEmpleado().subscribe(res => { this.TiposEmpleado = res; })
    this.rinkuService.GetAllEmpleado().subscribe(res => { this.ListEmpleados = res; })
    this.rinkuService.GetAllPeriodos().subscribe(res => { this.Periodos = res; })
  }
  SetSaveMovimiento() {
    this.movimientos = this.FormMovimientos.value;
    this.movimientos = this.CoonvertNumber(this.movimientos);

    this.rinkuService.SetNewMoviemiento(this.movimientos).subscribe(res => {
      if (Number(res) == 1) {
        window.alert("El movimiento fue agreagado correctamente");

      } else {
        window.alert("El movimiento no se agrego")
      }
    });


  }
  CoonvertNumber(movimiento: Movimientos) {
    movimiento.CvPeriodo = Number(movimiento.CvPeriodo);
    movimiento.CvEmpleado = Number(movimiento.CvEmpleado);
    movimiento.CvTipoEmpleado = Number(movimiento.CvTipoEmpleado);

    return movimiento;
  }



}
