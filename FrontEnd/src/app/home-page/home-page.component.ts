import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AppService } from '../Services';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { movieDetail } from '../Models';

@Component({
  selector: 'app-homepage',
  templateUrl: './home-page.component.html'
})
export class HomepageComponent implements OnInit {
  public allMovieDetails!: movieDetail[];

  constructor(private service:AppService, private router: Router) { }

  ngOnInit(): void {
    this.service.getAllMovieDetails().subscribe((data:any[]) => {
      this.allMovieDetails = data;
    })
  }

  selectedMovie(id: number) {  
    this.router.navigate(['view/'+id]);
  }
}
