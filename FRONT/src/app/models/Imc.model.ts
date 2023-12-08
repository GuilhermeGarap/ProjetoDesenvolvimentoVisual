import { Usuario } from "./Usuario.model";

export interface Imc {
    imcId?: number;
    altura: number;
    peso: number;
    imcCalculado?: number;
    classificacao?: string;
    criadoEm?: string;
    usuario?: Usuario;
    usuarioId: number;


}