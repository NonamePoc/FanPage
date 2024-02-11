»
xC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\UserProfile\FriendRequestDto.cs
	namespace 	
FanPage
 
. 
Application 
. 
UserProfile )
{ 
public 

class 
FriendRequestDto !
{ 
public 
string 
UserName 
{  
get! $
;$ %
set& )
;) *
}* +
public 
string 

FriendName  
{! "
get# &
;& '
set( +
;+ ,
}, -
public 
bool 
IsApproving 
{  !
get" %
;% &
set' *
;* +
}+ ,
}		 
}

 ù
qC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\UserProfile\FriendDto.cs
	namespace 	
FanPage
 
. 
Application 
. 
UserProfile )
{ 
public 

class 
	FriendDto 
{ 
public 
string 
UserName 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 

FriendName  
{! "
get# &
;& '
set( +
;+ ,
}- .
} 
} £
sC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\UserProfile\FollowerDto.cs
	namespace 	
FanPage
 
. 
Application 
. 
UserProfile )
{ 
public 

class 
FollowerDto 
{ 
public 
string 
UserName 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
FollowerName "
{# $
get% (
;( )
set* -
;- .
}/ 0
} 
}		 ¥
sC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\UserProfile\BookmarkDto.cs
	namespace 	
FanPage
 
. 
Application 
. 
UserProfile )
{ 
public 

class 
BookmarkDto 
{ 
public 
string 
UserId 
{ 
get "
;" #
set$ '
;' (
}) *
public 
int 
TitelId 
{ 
get  
;  !
set" %
;% &
}' (
public 
int 

BookmarkId 
{ 
get  #
;# $
set% (
;( )
}* +
}		 
}

 ¯
qC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\Url\UrlInformationDto.cs
	namespace 	
FanPage
 
. 
Application 
. 
Url !
{ 
public 

class 
UrlInformationDto "
{ 
public 
string 
BaseAddress !
{" #
get$ '
;' (
}) *
public 
string 
ControllerRoute %
{& '
get( +
;+ ,
}- .
public		 
string		 
MethodRoute		 !
{		" #
get		$ '
;		' (
}		) *
public 
UrlInformationDto  
(  !
string! '
baseAddress( 3
,3 4
string5 ;
controllerRoute< K
,K L
stringM S
methodRouteT _
)_ `
{ 	
BaseAddress 
= 
baseAddress %
;% &
ControllerRoute 
= 
controllerRoute -
;- .
MethodRoute 
= 
methodRoute %
;% &
} 	
public 
UrlInformationDto  
(  !
string! '
baseAddress( 3
,3 4
string5 ;
controllerRoute< K
)K L
{ 	
BaseAddress 
= 
baseAddress %
;% &
ControllerRoute 
= 
controllerRoute -
;- .
} 	
} 
} ∑
jC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\Photo\PhotoDto.cs
	namespace 	
FanPage
 
. 
Application 
. 
Photo #
{ 
public 

class 
PhotoDto 
{ 
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
public 
byte 
[ 
] 
Image 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
UserId 
{ 
get "
;" #
set$ '
;' (
}) *
}		 
}

 ©
xC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\GoogleAuth\GoogleResponseDto.cs
	namespace 	
FanPage
 
. 
Application 
. 

GoogleAuth (
;( )
public 
class 
GoogleResponseDto 
{ 
public 

string 
? 
Id 
{ 
get 
; 
set  
;  !
}" #
public 

string 
? 
Email 
{ 
get 
; 
set  #
;# $
}% &
public 

string 
? 
Name 
{ 
get 
; 
set "
;" #
}$ %
public 

string 
? 
Token 
{ 
get 
; 
set  #
;# $
}% &
public

 

string

 
?

 
Role

 
{

 
get

 
;

 
set

 "
;

" #
}

$ %
public 

string 
WhoBan 
{ 
get 
; 
set  #
;# $
}% &
public 

byte 
[ 
] 
? 

UserAvatar 
{ 
get  #
;# $
set% (
;( )
}* +
public 

DateTime 
LifeTimeToken !
{" #
get$ '
;' (
set) ,
;, -
}. /
} ∆	
lC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\Fanfic\UpdateDto.cs
	namespace 	
FanPage
 
. 
Application 
. 
Fanfic $
{ 
public 

class 
	UpdateDto 
{ 
public 
string 
Title 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
? 
Description "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
bool 
? 
OriginFandom !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
string 
? 
Stage 
{ 
get "
;" #
set$ '
;' (
}) *
public

 
List

 
<

 
FanficPhotoDto

 "
>

" #
Photo

$ )
{

* +
get

, /
;

/ 0
set

1 4
;

4 5
}

6 7
} 
} ˆ
iC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\Fanfic\TagDto.cs
	namespace 	
FanPage
 
. 
Application 
. 
Fanfic $
;$ %
public 
class 
TagDto 
{ 
public 

int 
TagId 
{ 
get 
; 
set 
;  
}! "
public 

string 
? 
Name 
{ 
get 
; 
set "
;" #
}$ %
public 

bool 

IsApproved 
{ 
get  
;  !
set" %
;% &
}' (
public

 

ICollection

 
<

 
FanficTagDto

 #
>

# $

FanficTags

% /
{

0 1
get

2 5
;

5 6
set

7 :
;

: ;
}

< =
} Ú	
mC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\Fanfic\ReviewsDto.cs
	namespace 	
FanPage
 
. 
Application 
. 
Fanfic $
;$ %
public 
class 

ReviewsDto 
{ 
public 

int 
ReviewId 
{ 
get 
; 
set "
;" #
}$ %
public 

string 
UserName 
{ 
get  
;  !
set" %
;% &
}' (
public		 

string		 
Text		 
{		 
get		 
;		 
set		 !
;		! "
}		# $
public 

double 
Rating 
{ 
get 
; 
set  #
;# $
}% &
public 

DateTimeOffset 
CreationDate &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 

int 
FanficId 
{ 
get 
; 
set "
;" #
}$ %
} ¨
oC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\Fanfic\FanficTagDto.cs
	namespace 	
FanPage
 
. 
Application 
. 
Fanfic $
{ 
public 

class 
FanficTagDto 
{ 
public 
int 
TagId 
{ 
get 
; 
set  #
;# $
}% &
public 
string 
TagName 
{ 
get  #
;# $
set% (
;( )
}* +
public 
bool 

isApproved 
{  
get! $
;$ %
set& )
;) *
}+ ,
}		 
}

 ±
qC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\Fanfic\FanficPhotoDto.cs
	namespace 	
FanPage
 
. 
Application 
. 
Fanfic $
{ 
public 

class 
FanficPhotoDto 
{ 
public 
byte 
[ 
] 
Image 
{ 
get !
;! "
set# &
;& '
}( )
public 
int 
FanficId 
{ 
get !
;! "
set# &
;& '
}( )
} 
} ≥
lC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\Fanfic\FanficDto.cs
	namespace 	
FanPage
 
. 
Application 
. 
Fanfic $
{ 
public 

class 
	FanficDto 
{ 
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
public 
string 

AuthorName  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
string 
Title 
{ 
get !
;! "
set# &
;& '
}( )
public		 
byte		 
[		 
]		 
?		 
Image		 
{		 
get		 "
;		" #
set		$ '
;		' (
}		) *
public 
string 
? 
Stage 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
? 
Language 
{  !
get" %
;% &
set' *
;* +
}, -
public 
string 
? 
Description "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
bool 
? 
OriginFandom !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
DateTimeOffset 
CreationDate *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
public 
List 
< 
CategoryDto 
>  
?  !

Categories" ,
{- .
get/ 2
;2 3
set4 7
;7 8
}9 :
public 
List 
< 
TagDto 
> 
? 
Tags !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
List 
< 

ChapterDto 
> 
?  
Chapters! )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 
List 
< 

ReviewsDto 
> 
?  
Reviews! (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
} 
} §
tC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\Fanfic\FanficCategoryDto.cs
	namespace 	
FanPage
 
. 
Application 
. 
Fanfic $
{ 
public 

class 
FanficCategoryDto "
{ 
public 
int 

CategoryId 
{ 
get  #
;# $
set% (
;( )
}* +
public 
string 
CategoryName "
{# $
get% (
;( )
set* -
;- .
}/ 0
} 
} â
lC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\Fanfic\CreateDto.cs
	namespace 	
FanPage
 
. 
Application 
. 
Fanfic $
{ 
public 

class 
	CreateDto 
{ 
public 
byte 
[ 
] 
? 
Image 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
? 
Description "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
bool 
OriginFandom  
{! "
get# &
;& '
set( +
;+ ,
}- .
public		 
string		 
Title		 
{		 
get		 !
;		! "
set		# &
;		& '
}		( )
public

 
string

 

AuthorName

  
{

! "
get

# &
;

& '
set

( +
;

+ ,
}

- .
public 
string 
? 
Stage 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
? 
Language 
{  !
get" %
;% &
set' *
;* +
}, -
public 
List 
< 
string 
> 

Categories &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
List 
< 
string 
> 
Tags  
{! "
get# &
;& '
set( +
;+ ,
}- .
} 
} ∂
rC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\Fanfic\CommentPhotoDto.cs
	namespace 	
FanPage
 
. 
Application 
. 
Fanfic $
;$ %
public 
class 
CommentPhotoDto 
{ 
public 

int 
Id 
{ 
get 
; 
set 
; 
} 
public 

byte 
[ 
] 
Image 
{ 
get 
; 
set "
;" #
}$ %
public 

int 
	CommentId 
{ 
get 
; 
set  #
;# $
}% &
} ±
mC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\Fanfic\ChapterDto.cs
	namespace 	
FanPage
 
. 
Application 
. 
Fanfic $
;$ %
public 
class 

ChapterDto 
{ 
public 

int 
	ChapterId 
{ 
get 
; 
set  #
;# $
}% &
public 

string 
Title 
{ 
get 
; 
set "
;" #
}$ %
public 

string 
Content 
{ 
get 
;  
set! $
;$ %
}& '
public 

int 
FanficId 
{ 
get 
; 
set "
;" #
}$ %
}		 ê

mC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\Fanfic\CommentDto.cs
	namespace 	
FanPage
 
. 
Application 
. 
Fanfic $
;$ %
public 
class 

CommentDto 
{ 
public 

int 
	CommentId 
{ 
get 
; 
set  #
;# $
}% &
public 

string 
Content 
{ 
get 
;  
set! $
;$ %
}& '
public		 

string		 

AuthorName		 
{		 
get		 "
;		" #
set		$ '
;		' (
}		) *
public 

DateTimeOffset 
	CreatedAt #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 

int 
FanficId 
{ 
get 
; 
set "
;" #
}$ %
public 

byte 
[ 
] 
Image 
{ 
get 
; 
set "
;" #
}$ %
} Ù
nC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\Fanfic\CategoryDto.cs
	namespace 	
FanPage
 
. 
Application 
. 
Fanfic $
;$ %
public 
class 
CategoryDto 
{ 
public 

int 

CategoryId 
{ 
get 
;  
set! $
;$ %
}& '
public 

string 
? 
Name 
{ 
get 
; 
set "
;" #
}$ %
public 

ICollection 
< 
FanficCategoryDto (
>( )
FanficCategories* :
{; <
get= @
;@ A
setB E
;E F
}G H
}		 ◊
xC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\CustomUserSetting\StickerDto.cs
	namespace 	
FanPage
 
. 
Application 
. 
CustomUserSetting /
;/ 0
public 
class 

StickerDto 
{ 
public 

int 
	StickerId 
{ 
get 
; 
set  #
;# $
}% &
public 

byte 
[ 
] 
Image 
{ 
get 
; 
set "
;" #
}$ %
public		 

int		 #
CustomizationSettingsId		 &
{		' (
get		) ,
;		, -
set		. 1
;		1 2
}		3 4
}

 ƒ
ÇC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\CustomUserSetting\CustomUserSettingDto.cs
	namespace 	
FanPage
 
. 
Application 
. 
CustomUserSetting /
;/ 0
public 
class  
CustomUserSettingDto !
{ 
public 

int #
CustomizationSettingsId &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 

ICollection 
< 

StickerDto !
>! "
CustomStickers# 1
{2 3
get4 7
;7 8
set9 <
;< =
}> ?
public 

byte 
[ 
] 
? 
BannerImage 
{  
get! $
;$ %
set& )
;) *
}+ ,
} Ω
kC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\Chat\MessageDto.cs
	namespace 	
FanPage
 
. 
Application 
. 
Chat "
;" #
public 
class 

MessageDto 
{ 
public 

string 
UserId 
{ 
get 
; 
set  #
;# $
}% &
public 

string 
Content 
{ 
get 
;  
set! $
;$ %
}& '
public		 

DateTimeOffset		 
ReceivedDateUtc		 )
{		* +
get		, /
;		/ 0
set		1 4
;		4 5
}		6 7
public 

int 
ChatId 
{ 
get 
; 
set  
;  !
}" #
} ï
lC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\Chat\ChatUserDto.cs
	namespace 	
FanPage
 
. 
Application 
. 
Chat "
;" #
public 
class 
ChatUserDto 
{ 
public 

string 
UserId 
{ 
get 
; 
set  #
;# $
}% &
public 

string 
UserName 
{ 
get  
;  !
set" %
;% &
}' (
public		 

int		 
ChatId		 
{		 
get		 
;		 
set		  
;		  !
}		" #
}

 
hC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\Chat\ChatDto.cs
	namespace 	
FanPage
 
. 
Application 
. 
Chat "
;" #
public 
class 
ChatDto 
{ 
public 

int 
Id 
{ 
get 
; 
set 
; 
} 
public 

string 
Name 
{ 
get 
; 
set !
;! "
}# $
public 

string 
Description 
{ 
get  #
;# $
set% (
;( )
}* +
public

 

string

 
Type

 
{

 
get

 
;

 
set

 !
;

! "
}

# $
public 

string 

AuthorName 
{ 
get "
;" #
set$ '
;' (
}) *
public 

ICollection 
< 
ChatUserDto "
>" #
	ChatUsers$ -
{. /
get0 3
;3 4
set5 8
;8 9
}: ;
public 

ICollection 
< 

MessageDto !
>! "
Messages# +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
} â
pC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\Auth\RefreshTokenDto.cs
	namespace 	
FanPage
 
. 
Application 
. 
Auth "
{ 
public 

class 
RefreshTokenDto  
{ 
public 
string 
? 
Token 
{ 
get "
;" #
set$ '
;' (
}) *
} 
} ¨
qC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\Auth\LogInResponseDto.cs
	namespace 	
FanPage
 
. 
Application 
. 
Auth "
{ 
public 

class 
LogInResponseDto !
{ 
public 
string 
? 
Id 
{ 
get 
;  
set! $
;$ %
}& '
public 
string 
? 
Email 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
? 
Name 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
? 
Token 
{ 
get "
;" #
set$ '
;' (
}) *
public

 
string

 
?

 
Role

 
{

 
get

 !
;

! "
set

# &
;

& '
}

( )
public 
string 
WhoBan 
{ 
get "
;" #
set$ '
;' (
}) *
public 
byte 
[ 
] 
? 

UserAvatar !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
DateTime 
LifeTimeToken %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
} 
} §
hC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\Auth\AuthDto.cs
	namespace 	
FanPage
 
. 
Application 
. 
Auth "
{ 
public 

class 
AuthDto 
{ 
public 
string 
? 
Email 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
? 
Password 
{  !
get" %
;% &
set' *
;* +
}, -
} 
} ¥	
uC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\Admin\UserInfoResponseDto.cs
	namespace 	
FanPage
 
. 
Application 
. 
Admin #
{ 
public 

class 
UserInfoResponseDto $
{ 
public 
string 
? 
Id 
{ 
get 
;  
set! $
;$ %
}& '
public 
string 
? 
Name 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
? 
Email 
{ 
get "
;" #
set$ '
;' (
}) *
public

 
string

 
?

 
PhoneNumber

 "
{

# $
get

% (
;

( )
set

* -
;

- .
}

/ 0
public 
string 
? 
Role 
{ 
get !
;! "
set# &
;& '
}( )
} 
} Ó
xC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\Admin\UserBanInfoResponseDto.cs
	namespace 	
FanPage
 
. 
Application 
. 
Admin #
{ 
public 

class "
UserBanInfoResponseDto '
{ 
public 
string 
Id 
{ 
get 
; 
set  #
;# $
}% &
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
	AdminName 
{  !
get" %
;% &
set' *
;* +
}, -
public

 
DateTimeOffset

 
?

 
BanTime

 &
{

' (
get

) ,
;

, -
set

. 1
;

1 2
}

3 4
} 
} Æ
oC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\Admin\ChangeRoleDto.cs
	namespace 	
FanPage
 
. 
Application 
. 
Admin #
{ 
public 

class 
ChangeRoleDto 
{ 
public 
string 
? 
Id 
{ 
get 
;  
set! $
;$ %
}& '
public 
string 
? 
NewRole 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
} ö
hC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\Admin\BanDto.cs
	namespace 	
FanPage
 
. 
Application 
. 
Admin #
{ 
public 

class 
BanDto 
{ 
public 
string 
? 
Id 
{ 
get 
;  
set! $
;$ %
}& '
public 
int 
? 
days 
{ 
get 
; 
set  #
;# $
}% &
} 
} Ω
vC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\Account\RestorePasswordDto.cs
	namespace 	
FanPage
 
. 
Application 
. 
Account %
{ 
public 

class 
RestorePasswordDto #
{ 
public 
string 
? 
Email 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
? 
Token 
{ 
get "
;" #
set$ '
;' (
}) *
} 
} ¿
{C:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\Account\RequestToChangeEmailDto.cs
	namespace 	
FanPage
 
. 
Application 
. 
Account %
{ 
public 

class #
RequestToChangeEmailDto (
{ 
public 
string 
NewEmail 
{  
get! $
;$ %
set& )
;) *
}+ ,
public		 
UrlInformationDto		  
ChangeEmailUrl		! /
{		0 1
get		2 5
;		5 6
set		7 :
;		: ;
}		< =
}

 
} „
}C:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\Account\RequestRestorePasswordDto.cs
	namespace 	
FanPage
 
. 
Application 
. 
Account %
{ 
public 

class %
RequestRestorePasswordDto *
{ 
public 
string 
? 
Email 
{ 
get "
;" #
set$ '
;' (
}) *
public		 
UrlInformationDto		  
?		  !
RestorePasswordUrl		" 4
{		5 6
get		7 :
;		: ;
set		< ?
;		? @
}		A B
}

 
} ì
sC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\Account\RegistrationDto.cs
	namespace 	
FanPage
 
. 
Application 
. 
Account %
{ 
public 

class 
RegistrationDto  
{ 
public 
string 
? 
UserName 
{  !
get" %
;% &
set' *
;* +
}, -
public		 
string		 
?		 
Email		 
{		 
get		 "
;		" #
set		$ '
;		' (
}		) *
public 
string 
? 
Password 
{  !
get" %
;% &
set' *
;* +
}, -
public 
UrlInformationDto  
ConfirmEmailUrl! 0
{1 2
get3 6
;6 7
set8 ;
;; <
}= >
} 
} ∑
sC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\Account\ConfirmEmailDto.cs
	namespace 	
FanPage
 
. 
Application 
. 
Account %
{ 
public 

class 
ConfirmEmailDto  
{ 
public 
string 
? 
Email 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
? 
Token 
{ 
get "
;" #
set$ '
;' (
}) *
} 
}		 ˆ
uC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\Account\ChangePasswordDto.cs
	namespace 	
FanPage
 
. 
Application 
. 
Account %
{ 
public 

class 
ChangePasswordDto "
{ 
public 
string 
? 
Password 
{  !
get" %
;% &
set' *
;* +
}, -
public 
string 
? 
ConfirmPassword &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
string 
? 
NewPassword "
{# $
get% (
;( )
set* -
;- .
}/ 0
} 
}		 ‡
rC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Application\Account\ChangeEmailDto.cs
	namespace 	
FanPage
 
. 
Application 
. 
Account %
{ 
public 

class 
ChangeEmailDto 
{ 
public 
string 
? 
Email 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
? 
NewEmail 
{  !
get" %
;% &
set' *
;* +
}, -
public		 
string		 
?		 
Token		 
{		 
get		 "
;		" #
set		$ '
;		' (
}		) *
}

 
} 