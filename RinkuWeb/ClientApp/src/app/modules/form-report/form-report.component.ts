import { Component, OnInit } from '@angular/core';
import { RinkuService } from '../../services/rinku.service';
@Component({
  selector: 'app-form-report',
  templateUrl: './form-report.component.html',
  styleUrls: ['./form-report.component.css']
})
export class FormReportComponent implements OnInit {
  query: any;
  constructor(private rinkuService: RinkuService) { }

  ngOnInit() {
    this.OnloadComponent();
  }

  OnloadComponent() {
    this.rinkuService.QueryNominas().subscribe(res => { console.log(res); this.query = res });
  }

  SetDeleteNomina(cv) {
    if (window.confirm("Desea eliminar el registo?")) {
      this.rinkuService.SetRemoveMovimiento(Number(cv)).subscribe(res => {
        if (res > 0) { window.alert("El registro fue eliminado"); this.OnloadComponent(); }
        else { window.alert("El registro no se pudo eliminar") }

      })
    }

  }

}
