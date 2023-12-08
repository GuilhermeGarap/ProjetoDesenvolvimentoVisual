import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Usuario } from 'src/app/models/Usuario.model';

@Component({
  selector: 'app-cadastrar-usuario',
  templateUrl: './cadastrar-usuario.component.html',
  styleUrls: ['./cadastrar-usuario.component.css']
})
export class CadastrarUsuarioComponent {
  constructor (private http: HttpClient, private router: Router) { }
  nome: string = "";
  data: string = "";

  cadastrar(): void {
    let usuario: Usuario = {
      nome: this.nome,
      data: this.data
    }

  this.http.post<Usuario[]>("http://localhost:5075/api/usuario/cadastrar", usuario).subscribe({
    next: (usuarios => {
      this.router.navigate(["/pages/imc/listar-imc"])
    }),
    error: (erro) =>  {
      console.log(erro)
    }
  })
}
}


