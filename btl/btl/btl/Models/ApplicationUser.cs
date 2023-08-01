//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace btl.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class ApplicationUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ApplicationUser()
        {
            this.ApplicationUserClaims = new HashSet<ApplicationUserClaim>();
            this.ApplicationUserLogins = new HashSet<ApplicationUserLogin>();
            this.ApplicationUserRoles = new HashSet<ApplicationUserRole>();
            this.Orders = new HashSet<Order>();
        }
        [DisplayName("Mã tài khoản")]
        public string Id { get; set; }
[DisplayName("Họ và tên")]
        public string FullName { get; set; }
[DisplayName("Địa chỉ")]
        public string Address { get; set; }
[DisplayName("Ngày sinh")]
        public Nullable<System.DateTime> BirthDay { get; set; }
[DisplayName("Email")]
        public string Email { get; set; }
[DisplayName("Xác nhận Email")]
        public bool EmailConfirmed { get; set; }
[DisplayName("Mật khẩu")]
        public string PasswordHash { get; set; }
[DisplayName("Tem bảo mật")]
        public string SecurityStamp { get; set; }
[DisplayName("Số điện thoại")]
        public string PhoneNumber { get; set; }
[DisplayName("Xác nhận số điện thoại")]
        public bool PhoneNumberConfirmed { get; set; }
[DisplayName("Hai yếu tố kích hoạt")]
        public bool TwoFactorEnabled { get; set; }
[DisplayName("Ngày kết thúc khóa")]
        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
[DisplayName("Bật khóa")]
        public bool LockoutEnabled { get; set; }
[DisplayName("Số lần đăng nhập thất bại")]
        public int AccessFailedCount { get; set; }
[DisplayName("Tên tài khoản")]
        public string UserName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ApplicationUserClaim> ApplicationUserClaims { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ApplicationUserLogin> ApplicationUserLogins { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
