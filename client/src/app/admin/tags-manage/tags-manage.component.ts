import { Component } from '@angular/core';
import { ThemeService } from '../../shared/theme.service';
import { CommonModule } from '@angular/common';
import { AdminService } from '../admin.service';

@Component({
  selector: 'app-tags-manage',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './tags-manage.component.html',
  styleUrl: './tags-manage.component.css',
})
export class TagsManageComponent {
  tags: any[] = [];

  constructor(
    private themeService: ThemeService,
    private adminService: AdminService
  ) {}

  ngOnInit(): void {
    this.themeService.setTheme(true);
    this.adminService.getTags().subscribe((tags) => {
      this.tags = tags;
    });
  }

  onApprove(tag: any) {
    this.adminService.approveTag(tag.id).subscribe((res) => {
      console.log('Approved', res);
    });
  }

  onReject(tag: any) {
    this.adminService.rejectTag(tag.id).subscribe(() => {
      this.tags = this.tags.filter((t) => t.id !== tag.id);
    });
  }
}
