import { Component, OnInit } from '@angular/core';
import { RinkuService } from '../../services/rinku.service';
@Component({
  selector: 'app-form-report',
  templateUrl: './form-report.component.html',
  styleUrls: ['./form-report.component.css']
})
export class FormReportComponent implements OnInit {
query:any;
  constructor(private rinkuService:RinkuService) { }

  ngOnInit() {
    this.OnloadComponenet();
  }

  OnloadComponenet(){
    this.rinkuService.QueryNominas().subscribe(res =>{console.log(res);this.query=res});
  }

}
