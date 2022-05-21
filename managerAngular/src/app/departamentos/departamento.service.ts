import { Departamento } from '../models/Departamento';
import { environment } from '../../environments/environment';
import { HttpClient } from "@angular/common/http";
import { Injectable,} from "@angular/core";
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DepartamentoService {

  baseUrl = `${environment.baseUrl}/departamento`;


  constructor(private http: HttpClient) {  }

  getAll(): Observable<Departamento[]> {
    return this.http.get<Departamento[]>(`${this.baseUrl}`);
  }

  post(departamento: Departamento) {
    return this.http.post(`${this.baseUrl}`, departamento);
  }
  put(id: number, departamento: Departamento) {
    return this.http.put(`${this.baseUrl}/${id}`, departamento);
  }
  delete(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

}