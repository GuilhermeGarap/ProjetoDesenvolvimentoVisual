namespace API.Models;

public class Imc {

    public int? ImcId { get; set; }
    public double Altura { get; set; }
    public double Peso { get; set; } 
    public double ImcCalculado { get; set; }
    public string? Classificacao { get; set; }
    public DateTime? CriadoEm { get; set; } = DateTime.Now;
    public Usuario? Usuario { get; set; }
    public int UsuarioId { get; set; }

    public Imc(){
        VerClassificacao();
    }

    // public double CalcularImc(double peso, double altura){
    //     return peso*altura;
    // }

    private void VerClassificacao() {
    if(ImcCalculado < 18.5) {
        Classificacao = "Magreza";
    } else if (ImcCalculado <= 18.5 && ImcCalculado<=24.9) {
        Classificacao = "Normal";
    }else if (ImcCalculado <= 25 && ImcCalculado<=29.9) {
        Classificacao ="Sobrepeso";
    }else if (ImcCalculado <= 30 && ImcCalculado<=39.9) {
        Classificacao ="Obesidade";
    }else {
        Classificacao ="Obesidade Grave";
    }
    }
}