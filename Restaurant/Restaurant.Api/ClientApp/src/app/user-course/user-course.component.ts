import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-user-course',
  templateUrl: './user-course.component.html',
  styleUrls: ['./user-course.component.css']
})
export class UserCourseComponent implements OnInit {

  public baseurl: string;
  public http: HttpClient;
  public userCourseList: UserCourseList[];

  constructor(_http: HttpClient, @Inject('BASE_URL') _baseUrl: string) {
    this.baseurl = _baseUrl;
    this.http = _http;
  
  }

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    let idUser = 1; // harcoded

    this.http.get<UserCourseList[]>(this.baseurl + 'api/usercourse/' + idUser).subscribe(result => {
      this.userCourseList = result;

    }, error => console.error(error));
  }

}

interface UserCourseList {
  userId: number;
  userName: string;
  courseId: number;
  courseDescription: string;
}
