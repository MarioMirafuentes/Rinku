import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, ReactiveFormsModule } from "@angular/forms";
import { ColDef, GridApi, } from 'ag-grid-community';
import { RinkuService } from '../../services/rinku.service';
import { Empleados } from '../../rinkuClass/empleados';

@Component({
  selector: 'app-form-empleados',
  templateUrl: './form-empleados.component.html',
  styleUrls: ['./form-empleados.component.css']
})
export class FormEmpleadosComponent implements OnInit {
  columsDefs: ColDef[] = [
    { headerName: 'CV', field: 'cvEmpleado', sortable: true, filter: true, width: 200, checkboxSelection: true, headerCheckboxSelection: true, },
    { headerName: 'Numero de Empleado', field: 'numeroEmpleado', sortable: true, filter: true, width: 200 },
    { headerName: 'Nombre', field: 'nombre', sortable: true, filter: true, width: 400 },

  ]
  private gridApi!: GridApi;
  public rowSelection = 'single';
  public multiple = 'single';
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

    this.ngOnInit()
    this.FormEmpleado.reset()
  }
  GetAllEmpleado() {
    
    this.ListEmpleados = null;
    this.rinkuService.GetAllEmpleado().subscribe(res => { this.ListEmpleados = res });
  }

  onSelectionChanged(event) {
    let data = event.api.getSelectedRows();

    this.rinkuService.GetEmpleado(data[0].cvEmpleado).subscribe(res => {
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
}


