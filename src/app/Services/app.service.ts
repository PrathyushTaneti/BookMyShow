import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AppService {
  public readonly bookMyShowAPIUrl = "https://localhost:44320/api";

  constructor(private http:HttpClient) { }

  ngOnInit() {
  }

  getAllMovieDetails():Observable<any[]> {
    return this.http.get<any>(this.bookMyShowAPIUrl + '/MovieDetail');
  }

  getMovieDetailById(id:number): Observable<any>{
    return this.http.get<any>(this.bookMyShowAPIUrl + `/movieDetail/${id}`);
  }
}
