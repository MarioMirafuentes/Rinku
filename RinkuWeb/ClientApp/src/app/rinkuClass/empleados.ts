

export class Empleados {
    CvEmpleado: number;
    NumeroEmpleado: string;
    Nombre: string;
}

export class Movimientos {

    CvMovimiento: number;
    Mes: number;
    NumEntregas: number;
    CvTipoEmpleado: number;
    CvEmpleado: number;
    Descripcion: string;
  CvPeriodo:number;
   HDesc:number;
}

export class Nomina{

      CvNomina :number;
     CvMovimiento :number;
      Bonos :number;
     Retenciones :number;
      CvPeriodo :number;
      ValesDespensa :number;

}
export class Periodos{
      CvPeriodo:number;
          NumMesPeriodo:number;
          MesPeriodo:string
          Descripcion:string;
}
export class TipoEmpleados{
     CvTipoEmpleado :number;
      NombreTipo :string
      TabuladorHora :number;
     Descripcion :string;
}