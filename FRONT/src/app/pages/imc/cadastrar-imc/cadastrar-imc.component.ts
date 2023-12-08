import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Usuario } from 'src/app/models/Usuario.model';
import { Imc } from 'src/app/models/Imc.model';

@Component({
  selector: 'app-cadastrar-imc',
  templateUrl: './cadastrar-imc.component.html',
  styleUrls: ['./cadastrar-imc.component.css']
})
export class CadastrarImcComponent {
  constructor (private http: HttpClient, private router: Router) { }
  altura: number = 0;
  peso: number = 0;
  usuarios: Usuario[] = [];
  usuarioId: number = 0;

  ngOnInit(): void {
    this.http.get<Usuario[]>("http://localhost:5075/api/usuario/listar")
    .subscribe({
      next: (usuarios) => {
        this.usuarios = usuarios;
      },
      error: (erro) => {
        console.log(erro);
      }
    })
  }

  cadastrar(): void {
    let imc: Imc = {
      altura: this.altura,
      peso: this.peso,
      usuarioId: this.usuarioId
    }

  this.http.post<Imc[]>("http://localhost:5075/api/imc/cadastrar", imc).subscribe({
    next: (imcs => {
      this.router.navigate(["/pages/imc/listar-imc"])
    }),
    error: (erro) =>  {
      console.log(erro)
    }
  })
}
}
