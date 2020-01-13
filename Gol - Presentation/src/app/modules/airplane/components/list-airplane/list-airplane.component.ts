import { Component, OnInit } from '@angular/core';
import { Airplane } from '../../models/airplane';
import { AirplaneService } from '../../services/airplane.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'gol-list-airplane',
  templateUrl: './list-airplane.component.html',
  styleUrls: ['./list-airplane.component.scss'],
})
export class ListAirplaneComponent implements OnInit {

  public airplanes: Airplane[];
  errorMessage: boolean;
  errors: any[] = [];

  constructor(private airplaneService: AirplaneService, private toastr: ToastrService, ) { }

  ngOnInit() {
    this.airplaneService.obterTodos()
      .subscribe(airplanes => this.airplanes = airplanes,
        error => this.errorMessage);
  }

  excluirAirplane(id) {
    this.airplaneService.excluirAirplane(id)
      .subscribe(
        result => { this.onExcludeComplete(id); },
        fail => { this.onError(fail); }
      );
  }

  onError(fail) {
    this.toastr.error('Ocorreu um erro no processamento', 'Ops! :(');
    this.errors = fail.error.errors;
  }

  onExcludeComplete(idExclude) {
    this.errors = [];
    this.airplanes.forEach((element, index) => {
      if (element.id == idExclude) { this.airplanes.splice(index, 1); }
    });
    this.toastr.success('Airplane Excluido com Sucesso! o alert de confirmação vem na proxima versão', 'Eita', { timeOut: 3000 });
  }

}
