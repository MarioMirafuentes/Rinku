import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, ReactiveFormsModule } from "@angular/forms";

import { RinkuService } from '../../services/rinku.service';
import { Empleados } from '../../rinkuClass/empleados';

@Component({
  selector: 'app-form-empleados',
  templateUrl: './form-empleados.component.html',
  styleUrls: ['./form-empleados.component.css']
})
export class FormEmpleadosComponent implements OnInit {


  FormEmpleado: FormGroup;
  ListEmpleados: Array<Empleados>
  constructor(private rinkuService: RinkuService,
    private empleado: Empleados,

  ) {
    this.FormEmpleado = new FormGroup({
      CvEmpleado: new FormControl(0),
      NumeroEmpleado: new FormControl("", [Validators.required]),
      Nombre: new FormControl("", [Validators.required]),

    })

  }

  ngOnInit() {
    this.GetAllEmpleado();
  }

  SetSaveEmpleado() {
    this.empleado = this.FormEmpleado.value;
    this.rinkuService.SetSaveEmpleado(this.empleado).subscribe(res => {
   
if (Number(res)==1) {
  window.alert("El empleado fue agreagado correctamente");

}else{
  window.alert("El empleado no se agrego")
}

    });

    this.GetAllEmpleado()
    this.FormEmpleado.reset()
  }
  GetAllEmpleado() {
    
    this.ListEmpleados = null;
    this.rinkuService.GetAllEmpleado().subscribe(res => { this.ListEmpleados = res });
  }

  onSelectionChanged(cvEmpleado) {
   

    this.rinkuService.GetEmpleado(Number(cvEmpleado)).subscribe(res => {
      this.FormEmpleado.controls["Nombre"].setValue(res.nombre)
      this.FormEmpleado.controls["NumeroEmpleado"].setValue(res.numeroEmpleado)
      this.FormEmpleado.controls["CvEmpleado"].setValue(res.cvEmpleado)
    });

  }

  GetRepet(num) {
    this.rinkuService.GetRepet(num.value).subscribe(res => {
      if (res > 0) {
        window.alert("El Numero de empleado ya existe");
      }

    })
  }

  SetDelEmpleado(num) {

    this.rinkuService.SetRemoveEmpleado(num).subscribe(res => {
      if (res > 0) {
        window.alert("Se elimino el registro.");
      }

    })
    this.GetAllEmpleado();
  }
}


