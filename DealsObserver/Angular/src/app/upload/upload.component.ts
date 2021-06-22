import { Component } from '@angular/core';
import {DealsHttpService} from '../shared/services/deals-http.service';

@Component({
  selector: 'upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent {
  private fileToUpload: File = null;

  constructor(private http: DealsHttpService) {
  }

  handleFileInput(files: FileList) {
    this.fileToUpload = files.item(0);
  }

  fileExists() {
    return this.fileToUpload != null;
  }

  uploadFile() {
    this.http.uploadCsv(this.fileToUpload)
      .subscribe(() => {
        alert('File successfully uploaded');
      });
  }

}
