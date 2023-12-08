import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Imc } from 'src/app/models/Imc.model';

@Component({
  selector: 'app-listar-imc',
  templateUrl: './listar-imc.component.html',
  styleUrls: ['./listar-imc.component.css']
})
export class ListarImcComponent {
  constructor (private http: HttpClient) { }
  imcs: Imc[] = [];

  ngOnInit(): void {
    this.http.get<Imc[]>("http://localhost:5075/api/imc/listar")
    .subscribe({
      next: (imcs) => {
        this.imcs = imcs;
      },
      error: (erro) => {
        console.log(erro);
      }
    })
  }
}
