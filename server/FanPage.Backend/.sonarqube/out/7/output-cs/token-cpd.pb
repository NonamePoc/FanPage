�
vC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Infrastructure\Interfaces\User\IFriend.cs
	namespace 	
FanPage
 
. 
Infrastructure  
.  !

Interfaces! +
.+ ,
User, 0
{ 
public 

	interface 
IFriend 
{ 
Task 
< 
FriendRequestDto 
> 
	AddFriend (
(( )
HttpRequest) 4
request5 <
,< =
string> D

friendNameE O
)O P
;P Q
Task		 
<		 
bool		 
>		 
RemoveFriend		 
(		  
HttpRequest		  +
request		, 3
,		3 4
string		5 ;

friendName		< F
)		F G
;		G H
Task

 
<

 
List

 
<

 
	FriendDto

 
>

 
>

 
FriendsList

 )
(

) *
HttpRequest

* 5
request

6 =
)

= >
;

> ?
Task 
< 
List 
< 
FriendRequestDto "
>" #
># $
GetFriendRequests% 6
(6 7
HttpRequest7 B
requestC J
)J K
;K L
Task 
< 
bool 
> 

CancelSend 
( 
HttpRequest )
request* 1
,1 2
string3 9

friendName: D
)D E
;E F
Task 
< 
List 
< 
FriendRequestDto "
>" #
># $
GetUserRequests% 4
(4 5
HttpRequest5 @
requestA H
)H I
;I J
Task 
< 
bool 
> 
AcceptFriend 
(  
HttpRequest  +
request, 3
,3 4
string5 ;

friendName< F
)F G
;G H
} 
} �
xC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Infrastructure\Interfaces\User\IFollower.cs
	namespace 	
FanPage
 
. 
Infrastructure  
.  !

Interfaces! +
.+ ,
User, 0
;0 1
public 
	interface 
	IFollower 
{ 
Task 
< 	
List	 
< 
FollowerDto 
> 
> 
FollowerList (
(( )
HttpRequest) 4
request5 <
)< =
;= >
Task

 
<

 	
bool

	 
>

 
	Subscribe

 
(

 
HttpRequest

 $
request

% ,
,

, -
int

. 1
followerUserId

2 @
)

@ A
;

A B
Task 
< 	
bool	 
> 
Unsubscribe 
( 
HttpRequest &
request' .
,. /
int0 3
followerUserId4 B
)B C
;C D
} �
�C:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Infrastructure\Interfaces\User\ICustomizationSettings.cs
	namespace 	
FanPage
 
. 
Infrastructure  
.  !

Interfaces! +
.+ ,
User, 0
;0 1
public 
	interface "
ICustomizationSettings '
{ 
Task 
< 	 
CustomUserSettingDto	 
> 
ChangeBannerImage 0
(0 1
int1 4#
customizationSettingsId5 L
,L M
byteN R
[R S
]S T
bannerImageU `
,` a
HttpRequestb m
requestn u
)u v
;v w
Task

 
<

 	 
CustomUserSettingDto

	 
>

 $
GetCustomizationSettings

 7
(

7 8
int

8 ;#
customizationSettingsId

< S
,

S T
HttpRequest

U `
request

a h
)

h i
;

i j
} �
xC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Infrastructure\Interfaces\User\IBookmark.cs
	namespace		 	
FanPage		
 
.		 
Infrastructure		  
.		  !

Interfaces		! +
.		+ ,
User		, 0
{

 
public 

	interface 
	IBookmark 
{ 
Task 
< 
List 
< 
BookmarkDto 
> 
> 
BookmarkList  ,
(, -
HttpRequest- 8
request9 @
)@ A
;A B
Task 
< 
bool 
> 
Add 
( 
HttpRequest "
request# *
,* +
int, /
titelId0 7
)7 8
;8 9
Task 
< 
bool 
> 
Delete 
( 
HttpRequest %
request& -
,- .
int/ 2
titelId3 :
): ;
;; <
} 
} �
tC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Infrastructure\Interfaces\User\IAuth.cs
	namespace 	
FanPage
 
. 
Infrastructure  
.  !

Interfaces! +
.+ ,
User, 0
{ 
public 

	interface 
IAuth 
{ 
Task		 
<		 
LogInResponseDto		 
>		 
LogIn		 $
(		$ %
AuthDto		% ,
auth		- 1
)		1 2
;		2 3
Task 
LogOut 
( 
HttpRequest 
request  '
)' (
;( )
Task 
< 
RefreshTokenDto 
> 
RefreshToken *
(* +
HttpRequest+ 6
request7 >
)> ?
;? @
Task 
< 
GoogleResponseDto 
> 
GoogleLogin  +
(+ ,
string, 2
googleToken3 >
)> ?
;? @
} 
} �
uC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Infrastructure\Interfaces\User\IAdmin.cs
	namespace 	
FanPage
 
. 
Infrastructure  
.  !

Interfaces! +
.+ ,
User, 0
{ 
public 

	interface 
IAdmin 
{		 
Task

 
<

 
bool

 
>

 
Delete

 
(

 
string

  
Id

! #
)

# $
;

$ %
Task 
< 
bool 
> 
Ban 
( 
BanDto 
user "
," #
HttpRequest$ /
request0 7
)7 8
;8 9
Task 
< 
bool 
> 
Unban 
( 
string 
Id  "
)" #
;# $
Task 
< 
IdentityResult 
> 

ChangeRole '
(' (
ChangeRoleDto( 5
user6 :
): ;
;; <
Task 
< 
List 
< "
UserBanInfoResponseDto (
>( )
>) *
GetUserInBan+ 7
(7 8
)8 9
;9 :
Task 
< 
List 
< 
UserInfoResponseDto %
>% &
>& '
AllUsers( 0
(0 1
)1 2
;2 3
Task 
< 
bool 
> 

ApproveTag 
( 
int !
tagId" '
,' (
HttpRequest) 4
request5 <
)< =
;= >
Task 
< 
UserInfoResponseDto  
>  !
GetAdminAsync" /
(/ 0
HttpRequest0 ;
request< C
)C D
;D E
Task 
< 
UserInfoResponseDto  
>  !
GetModeratorAsync" 3
(3 4
HttpRequest4 ?
request@ G
)G H
;H I
Task 
< 
UserInfoResponseDto  
>  !
GetUserRoleAsync" 2
(2 3
string3 9
userName: B
)B C
;C D
Task 
< 
List 
< 
TagDto 
> 
> 
GetNotApprovedTags -
(- .
). /
;/ 0
} 
} �
wC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Infrastructure\Interfaces\User\IAccount.cs
	namespace 	
FanPage
 
. 
Infrastructure  
.  !

Interfaces! +
.+ ,
User, 0
{ 
public 

	interface 
IAccount 
{ 
Task		 
Registration		 
(		 
RegistrationDto		 )
registration		* 6
)		6 7
;		7 8
Task 
ConfirmEmail 
( 
ConfirmEmailDto )
confirmEmail* 6
)6 7
;7 8
Task 
ChangeEmail 
( 
ChangeEmailDto '
changeEmail( 3
)3 4
;4 5
Task 
ChangePassword 
( 
ChangePasswordDto -
changePassword. <
,< =
HttpRequest> I
requestJ Q
)Q R
;R S
Task "
RequestRestorePassword #
(# $%
RequestRestorePasswordDto$ ="
requestRestorePassword> T
)T U
;U V
Task 
RestorePassword 
( 
RestorePasswordDto /
restore0 7
)7 8
;8 9
Task  
RequestToChangeEmail !
(! "#
RequestToChangeEmailDto" 9
changeEmail: E
,E F
HttpRequestG R
requestS Z
)Z [
;[ \
Task 
< 
LogInResponseDto 
> 
GetUserInfo *
(* +
string+ 1
userId2 8
)8 9
;9 :
Task 
GoogleRegistration 
(  
string  &
googleToken' 2
)2 3
;3 4
} 
} �
pC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Infrastructure\Interfaces\IPhoto.cs
	namespace 	
FanPage
 
. 
Infrastructure  
.  !

Interfaces! +
{ 
public 

	interface 
IPhoto 
{ 
Task 
Create 
( 
PhotoDto 
createPhoto (
)( )
;) *
Task		 
Delete		 
(		 
int		 
id		 
)		 
;		 
Task 
Update 
( 
int 
id 
, 
PhotoDto $
updatePhoto% 0
)0 1
;1 2
} 
} �
uC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Infrastructure\Interfaces\Fanfic\ITag.cs
	namespace 	
FanPage
 
. 
Infrastructure  
.  !

Interfaces! +
.+ ,
Fanfic, 2
;2 3
public 
	interface 
ITag 
{ 
Task 
< 	
TagDto	 
> 
CreateTagAsync 
(  
int  #
fanficId$ ,
,, -
TagDto. 4
tagDto5 ;
,; <
HttpRequest= H
requestI P
)P Q
;Q R
Task

 
<

 	
TagDto

	 
>

 
SetTagAsync

 
(

 
int

  
fanficId

! )
,

) *
string

+ 1
?

1 2
name

3 7
,

7 8
HttpRequest

9 D
request

E L
)

L M
;

M N
Task 
DeleteTagAsync	 
( 
int 
tagId !
,! "
HttpRequest# .
request/ 6
)6 7
;7 8
Task 
< 	
TagDto	 
>  
DeleteTagFanficAsync %
(% &
int& )
fanficId* 2
,2 3
string4 :
?: ;
tagName< C
,C D
HttpRequestE P
requestQ X
)X Y
;Y Z
Task 
< 	
List	 
< 
TagDto 
> 
> 
GetAllTagFanfic &
(& '
int' *
fanficId+ 3
)3 4
;4 5
Task 
< 	
List	 
< 
TagDto 
> 
> 
GetAllTagAsync %
(% &
)& '
;' (
} �
xC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Infrastructure\Interfaces\Fanfic\IReview.cs
	namespace 	
FanPage
 
. 
Infrastructure  
.  !

Interfaces! +
.+ ,
Fanfic, 2
;2 3
public 
	interface 
IReview 
{ 
Task 
< 	

ReviewsDto	 
> 
CreateReviewAsync &
(& '
int' *
fanficId+ 3
,3 4

ReviewsDto5 ?

reviewsDto@ J
,J K
HttpRequestL W
requestX _
)_ `
;` a
Task

 
<

 	

ReviewsDto

	 
>

 
UpdateReviewAsync

 &
(

& '
int

' *
fanficId

+ 3
,

3 4

ReviewsDto

5 ?

reviewsDto

@ J
,

J K
HttpRequest

L W
request

X _
)

_ `
;

` a
Task 
DeleteReviewAsync	 
( 
int 
fanficId '
,' (
HttpRequest) 4
request5 <
)< =
;= >
Task 
< 	

ReviewsDto	 
> $
GetReviewByFanficIdAsync -
(- .
int. 1
fanficId2 :
,: ;
string< B
userNameC K
)K L
;L M
Task 
< 	
List	 
< 

ReviewsDto 
> 
> '
GetAllReviewByFanficIdAsync 6
(6 7
int7 :
fanficId; C
)C D
;D E
Task 
< 	
List	 
< 

ReviewsDto 
> 
> '
GetAllReviewByUserNameAsync 6
(6 7
string7 =
userName> F
)F G
;G H
Task 
< 	
List	 
< 

ReviewsDto 
> 
> 
GetAllReview '
(' (
)( )
;) *
} �
~C:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Infrastructure\Interfaces\Fanfic\IFanficDetail.cs
	namespace 	
FanPage
 
. 
Infrastructure  
.  !

Interfaces! +
.+ ,
Fanfic, 2
;2 3
public 
	interface 
IFanficDetail 
{ 
Task 
< 	
double	 
> !
GetAverageRatingAsync &
(& '
int' *
fanficId+ 3
)3 4
;4 5
Task		 
<		 	
List			 
<		 
	FanficDto		 
>		 
>		 
SearchAsync		 %
(		% &
string		& ,
searchString		- 9
,		9 :
bool		; ?
original		@ H
)		H I
;		I J
Task 
< 	
List	 
< 
	FanficDto 
> 
> 
GetAllAsync %
(% &
int& )
count* /
)/ 0
;0 1
Task 
< 	
List	 
< 
	FanficDto 
> 
>  
GetByAuthorNameAsync .
(. /
string/ 5
name6 :
,: ;
int< ?
count@ E
)E F
;F G
Task 
< 	
List	 
< 
	FanficDto 
> 
> +
GetLastCreationDateFanficsAsync 9
(9 :
int: =
count> C
,C D
HttpRequestE P
requestQ X
)X Y
;Y Z
Task 
< 	
List	 
< 
	FanficDto 
> 
> $
GetTopRatingFanficsAsync 2
(2 3
int3 6
count7 <
,< =
HttpRequest> I
requestJ Q
)Q R
;R S
Task 
< 	
	FanficDto	 
> 
GetByIdAsync  
(  !
int! $
id% '
)' (
;( )
} �
xC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Infrastructure\Interfaces\Fanfic\IFanfic.cs
	namespace 	
FanPage
 
. 
Infrastructure  
.  !

Interfaces! +
.+ ,
Fanfic, 2
{ 
public 

	interface 
IFanfic 
{ 
Task 
< 
	FanficDto 
> 
CreateAsync #
(# $
	CreateDto$ -
createFanfic. :
,: ;
HttpRequest< G
requestH O
)O P
;P Q
Task

 
<

 
	FanficDto

 
>

 
UpdateAsync

 #
(

# $
int

$ '
fanficId

( 0
,

0 1
	UpdateDto

2 ;
updateFanfic

< H
,

H I
HttpRequest

J U
request

V ]
)

] ^
;

^ _
Task 
DeleteAsync 
( 
int 
id 
,  
HttpRequest! ,
request- 4
)4 5
;5 6
} 
} �
yC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Infrastructure\Interfaces\Fanfic\IComment.cs
	namespace 	
FanPage
 
. 
Infrastructure  
.  !

Interfaces! +
.+ ,
Fanfic, 2
;2 3
public 
	interface 
IComment 
{ 
Task 
< 	

CommentDto	 
> 
AddCommentAsync $
($ %

CommentDto% /

commentDto0 :
,: ;
HttpRequest< G
requestH O
)O P
;P Q
Task		 
<		 	

CommentDto			 
>		 
UpdateCommentAsync		 '
(		' (

CommentDto		( 2

commentDto		3 =
,		= >
HttpRequest		? J
request		K R
)		R S
;		S T
Task

 
DeleteCommentAsync

	 
(

 
int

 
id

  "
,

" #
HttpRequest

$ /
request

0 7
)

7 8
;

8 9
Task 
< 	

CommentDto	 
> %
GetCommentByFanficIdAsync .
(. /
int/ 2
id3 5
,5 6
HttpRequest7 B
requestC J
)J K
;K L
Task 
< 	
List	 
< 

CommentDto 
> 
> &
GetCommentsByFanficIdAsync 5
(5 6
int6 9
fanficId: B
,B C
HttpRequestD O
requestP W
)W X
;X Y
Task 
< 	

CommentDto	 
> 
ReplyCommentAsync &
(& '

CommentDto' 1

commentDto2 <
,< =
HttpRequest> I
requestJ Q
)Q R
;R S
} �
yC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Infrastructure\Interfaces\Fanfic\IChapter.cs
	namespace 	
FanPage
 
. 
Infrastructure  
.  !

Interfaces! +
.+ ,
Fanfic, 2
;2 3
public 
	interface 
IChapter 
{ 
Task 
< 	

ChapterDto	 
> 
CreateChapterAsync '
(' (

ChapterDto( 2

chapterDto3 =
,= >
HttpRequest? J
requestK R
)R S
;S T
Task		 
<		 	

ChapterDto			 
>		 
UpdateChapterAsync		 '
(		' (
int		( +
	chapterId		, 5
,		5 6

ChapterDto		7 A

chapterDto		B L
,		L M
HttpRequest		N Y
request		Z a
)		a b
;		b c
Task

 
DeleteChapterAsync

	 
(

 
int

 
id

  "
,

" #
HttpRequest

$ /
request

0 7
)

7 8
;

8 9
Task 
< 	
List	 
< 

ChapterDto 
> 
> )
GetAllChaptersByFanficIdAsync 8
(8 9
int9 <
fanficId= E
)E F
;F G
Task 
< 	
List	 
< 

ChapterDto 
> 
> 
GetAllChaptersAsync .
(. /
)/ 0
;0 1
Task 
< 	

ChapterDto	 
> 
GetByIdAsync !
(! "
int" %
id& (
)( )
;) *
} �	
zC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Infrastructure\Interfaces\Fanfic\ICategory.cs
	namespace 	
FanPage
 
. 
Infrastructure  
.  !

Interfaces! +
.+ ,
Fanfic, 2
;2 3
public 
	interface 
	ICategory 
{ 
Task 
< 	
CategoryDto	 
> 
SetCategoryAsync &
(& '
int' *
fanficId+ 3
,3 4
string5 ;
categoryName< H
,H I
HttpRequestJ U
requestV ]
)] ^
;^ _
Task

 
DeleteCategoryAsync

	 
(

 
int

  
fanficId

! )
,

) *
int

+ .

categoryId

/ 9
,

9 :
HttpRequest

; F
request

G N
)

N O
;

O P
Task 
< 	
List	 
< 
CategoryDto 
> 
>  
GetAllCategoryFanfic 0
(0 1
int1 4
fanficId5 =
)= >
;> ?
} �
tC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Infrastructure\Interfaces\Chat\IChat.cs
	namespace 	
FanPage
 
. 
Infrastructure  
.  !

Interfaces! +
.+ ,
Chat, 0
;0 1
public 
	interface 
IChat 
{ 
Task 
< 	
ChatDto	 
> 
GetChatAsync 
( 
int "
id# %
,% &
string' -
type. 2
,2 3
HttpRequest4 ?
request@ G
)G H
;H I
Task

 
<

 	
List

	 
<

 
ChatDto

 
>

 
>

 
GetChatsAsync

 %
(

% &
string

& ,
type

- 1
,

1 2
HttpRequest

3 >
request

? F
)

F G
;

G H
Task 
CreateMessageAsync	 
( 
int 
chatId  &
,& '
string( .
type/ 3
,3 4

MessageDto5 ?
message@ G
,G H
HttpRequestI T
requestU \
)\ ]
;] ^
Task 
< 	
ChatDto	 
> 
CreateAsync 
( 
ChatDto %
chat& *
,* +
HttpRequest, 7
request8 ?
)? @
;@ A
Task 
< 	
ChatDto	 
> 
UpdateAsync 
( 
ChatDto %
chat& *
,* +
HttpRequest, 7
request8 ?
)? @
;@ A
Task 
DeleteAsync	 
( 
int 
id 
, 
string #
type$ (
,( )
HttpRequest* 5
request6 =
)= >
;> ?
Task #
RemoveUserFromChatAsync	  
(  !
int! $
chatId% +
,+ ,
string- 3
userId4 :
,: ;
string< B
typeC G
,G H
HttpRequestI T
requestU \
)\ ]
;] ^
Task !
InviteUserToChatAsync	 
( 
int "
chatId# )
,) *
string+ 1
userId2 8
,8 9
string: @
userNameA I
,I J
HttpRequestK V
requestW ^
)^ _
;_ `
Task 
< 	
List	 
< 
ChatDto 
> 
> 
GetChatRequestAsync +
(+ ,
string, 2
userId3 9
,9 :
HttpRequest; F
requestG N
)N O
;O P
Task !
AcceptUserToChatAsync	 
( 
int "
chatId# )
,) *
string+ 1
userId2 8
,8 9
HttpRequest: E
requestF M
)M N
;N O
Task "
DeclineUserToChatAsync	 
(  
int  #
chatId$ *
,* +
string, 2
userId3 9
,9 :
HttpRequest; F
requestG N
)N O
;O P
Task 
< 	
ChatDto	 
> 
SearchChatAsync !
(! "
string" (
search) /
,/ 0
HttpRequest0 ;
request< C
)C D
;D E
} �3
�C:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Infrastructure\Implementations\User\FriendService.cs
	namespace 	
FanPage
 
. 
Infrastructure  
.  !
Implementations! 0
.0 1
User1 5
{ 
public		 

class		 
FriendService		 
:		  
IFriend		! (
{

 
private 
readonly 
IFriendRepository *
_friendRepository+ <
;< =
private 
readonly 
IJwtTokenManager )
_jwtTokenManager* :
;: ;
public 
FriendService 
( 
IFriendRepository .
friendRepository/ ?
,? @
IJwtTokenManagerA Q
jwtTokenManagerR a
)a b
{ 	
_friendRepository 
= 
friendRepository  0
;0 1
_jwtTokenManager 
= 
jwtTokenManager .
;. /
} 	
public 
async 
Task 
< 
FriendRequestDto *
>* +
	AddFriend, 5
(5 6
HttpRequest6 A
requestB I
,I J
stringK Q

friendNameR \
)\ ]
{ 	
var 
userName 
= 
_jwtTokenManager +
.+ , 
GetUserNameFromToken, @
(@ A
requestA H
)H I
;I J
await 
_friendRepository #
.# $
	AddFriend$ -
(- .
userName. 6
,6 7

friendName8 B
)B C
;C D
return 
new 
FriendRequestDto '
{ 
UserName 
= 
userName %
,% &

FriendName' 1
=2 3

friendName4 >
}? @
;@ A
} 	
public 
async 
Task 
< 
List 
< 
	FriendDto (
>( )
>) *
FriendsList+ 6
(6 7
HttpRequest7 B
requestC J
)J K
{ 	
var 
userName 
= 
_jwtTokenManager +
.+ , 
GetUserNameFromToken, @
(@ A
requestA H
)H I
;I J
var   
list   
=   
await   
_friendRepository   .
.  . /
FriendsList  / :
(  : ;
userName  ; C
)  C D
;  D E
return!! 
list!! 
;!! 
}"" 	
public$$ 
async$$ 
Task$$ 
<$$ 
bool$$ 
>$$ 
RemoveFriend$$  ,
($$, -
HttpRequest$$- 8
request$$9 @
,$$@ A
string$$B H
friendId$$I Q
)$$Q R
{%% 	
var&& 
userName&& 
=&& 
_jwtTokenManager&& +
.&&+ , 
GetUserNameFromToken&&, @
(&&@ A
request&&A H
)&&H I
;&&I J
await'' 
_friendRepository'' #
.''# $
RemoveFriend''$ 0
(''0 1
userName''1 9
,''9 :
friendId''; C
)''C D
;''D E
return(( 
true(( 
;(( 
})) 	
public++ 
async++ 
Task++ 
<++ 
List++ 
<++ 
FriendRequestDto++ /
>++/ 0
>++0 1
GetFriendRequests++2 C
(++C D
HttpRequest++D O
request++P W
)++W X
{,, 	
var-- 
userName-- 
=-- 
_jwtTokenManager-- +
.--+ , 
GetUserNameFromToken--, @
(--@ A
request--A H
)--H I
;--I J
var.. 
list.. 
=.. 
await.. 
_friendRepository.. .
.... /
GetFriendRequests../ @
(..@ A
userName..A I
)..I J
;..J K
return// 
list// 
;// 
}00 	
public22 
async22 
Task22 
<22 
bool22 
>22 

CancelSend22  *
(22* +
HttpRequest22+ 6
request227 >
,22> ?
string22@ F

friendName22G Q
)22Q R
{33 	
var44 
userName44 
=44 
_jwtTokenManager44 +
.44+ , 
GetUserNameFromToken44, @
(44@ A
request44A H
)44H I
;44I J
await55 
_friendRepository55 #
.55# $

CancelSend55$ .
(55. /
userName55/ 7
,557 8

friendName559 C
)55C D
;55D E
return66 
true66 
;66 
}77 	
public99 
async99 
Task99 
<99 
List99 
<99 
FriendRequestDto99 /
>99/ 0
>990 1
GetUserRequests992 A
(99A B
HttpRequest99B M
request99N U
)99U V
{:: 	
var;; 
userName;; 
=;; 
_jwtTokenManager;; +
.;;+ , 
GetUserNameFromToken;;, @
(;;@ A
request;;A H
);;H I
;;;I J
var<< 
list<< 
=<< 
await<< 
_friendRepository<< .
.<<. /
GetUserRequests<</ >
(<<> ?
userName<<? G
)<<G H
;<<H I
return>> 
list>> 
;>> 
}?? 	
publicAA 
asyncAA 
TaskAA 
<AA 
boolAA 
>AA 
AcceptFriendAA  ,
(AA, -
HttpRequestAA- 8
requestAA9 @
,AA@ A
stringAAB H

friendNameAAI S
)AAS T
{BB 	
varCC 
userNameCC 
=CC 
_jwtTokenManagerCC +
.CC+ , 
GetUserNameFromTokenCC, @
(CC@ A
requestCCA H
)CCH I
;CCI J
awaitDD 
_friendRepositoryDD #
.DD# $
AcceptFriendDD$ 0
(DD0 1
userNameDD1 9
,DD9 :

friendNameDD; E
)DDE F
;DDF G
returnEE 
trueEE 
;EE 
}FF 	
}GG 
}HH �
�C:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Infrastructure\Implementations\User\FollowerService.cs
	namespace 	
FanPage
 
. 
Infrastructure  
.  !
Implementations! 0
.0 1
User1 5
{ 
public		 

class		 
FollowerService		  
:		! "
	IFollower		# ,
{

 
private 
readonly 
IFollowerRepository ,
_repository- 8
;8 9
private 
readonly 
IJwtTokenManager )
_jwtTokenManager* :
;: ;
public 
FollowerService 
( 
IFollowerRepository 2

repository3 =
,= >
IJwtTokenManager? O
jwtTokenManagerP _
)_ `
{ 	
_repository 
= 

repository $
;$ %
_jwtTokenManager 
= 
jwtTokenManager .
;. /
} 	
public 
async 
Task 
< 
List 
< 
FollowerDto *
>* +
>+ ,
FollowerList- 9
(9 :
HttpRequest: E
requestF M
)M N
{ 	
var 
userName 
= 
_jwtTokenManager +
.+ , 
GetUserNameFromToken, @
(@ A
requestA H
)H I
;I J
var 
list 
= 
await 
_repository (
.( )
FollowerList) 5
(5 6
userName6 >
)> ?
;? @
return 
list 
; 
} 	
public 
async 
Task 
< 
bool 
> 
	Subscribe  )
() *
HttpRequest* 5
request6 =
,= >
int? B
followerUserIdC Q
)Q R
{ 	
var 
userId 
= 
_jwtTokenManager )
.) * 
GetUserNameFromToken* >
(> ?
request? F
)F G
;G H
await 
_repository 
. 
	Subscribe '
(' (
followerUserId( 6
,6 7
userId8 >
)> ?
;? @
return   
true   
;   
}!! 	
public## 
async## 
Task## 
<## 
bool## 
>## 
Unsubscribe##  +
(##+ ,
HttpRequest##, 7
request##8 ?
,##? @
int##A D
followerUserId##E S
)##S T
{$$ 	
var%% 
userName%% 
=%% 
_jwtTokenManager%% +
.%%+ , 
GetUserNameFromToken%%, @
(%%@ A
request%%A H
)%%H I
;%%I J
await&& 
_repository&& 
.&& 
Unsubscribe&& )
(&&) *
followerUserId&&* 8
,&&8 9
userName&&: B
)&&B C
;&&C D
return'' 
true'' 
;'' 
}(( 	
})) 
}** �"
�C:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Infrastructure\Implementations\User\CustomizationSettingsService.cs
	namespace 	
FanPage
 
. 
Infrastructure  
.  !
Implementations! 0
.0 1
User1 5
{ 
public		 

class		 (
CustomizationSettingsService		 -
:		. /"
ICustomizationSettings		0 F
{

 
private 
readonly ,
 ICustomizationSettingsRepository 9"
_customizationSettings: P
;P Q
private 
readonly 
IJwtTokenManager )
_jwtTokenManager* :
;: ;
public (
CustomizationSettingsService +
(+ ,,
 ICustomizationSettingsRepository, L!
customizationSettingsM b
,b c
IJwtTokenManager 
jwtTokenManager ,
), -
{ 	"
_customizationSettings "
=# $!
customizationSettings% :
;: ;
_jwtTokenManager 
= 
jwtTokenManager .
;. /
} 	
public 
async 
Task 
<  
CustomUserSettingDto .
>. /
ChangeBannerImage0 A
(A B
intB E#
customizationSettingsIdF ]
,] ^
byte_ c
[c d
]d e
bannerImagef q
,q r
HttpRequest 
request 
)  
{ 	
var !
customizationSettings %
=& '
await( -"
_customizationSettings. D
.D E$
GetCustomizationSettingsE ]
(] ^#
customizationSettingsId^ u
)u v
;v w
if 
( !
customizationSettings %
==& (
null) -
)- .
throw/ 4
new5 8
	Exception9 B
(B C
$strC e
)e f
;f g
var 
userId 
= 
_jwtTokenManager )
.) *
GetUserIdFromToken* <
(< =
request= D
)D E
;E F
if 
( 
userId 
!= 
null 
) 
throw  %
new& )
	Exception* 3
(3 4
$str4 D
)D E
;E F
await!! "
_customizationSettings!! (
.!!( )
ChangeBannerImage!!) :
(!!: ;#
customizationSettingsId!!; R
,!!R S
bannerImage!!T _
)!!_ `
;!!` a
return## 
new##  
CustomUserSettingDto## +
{$$ 
BannerImage%% 
=%% 
bannerImage%% )
,%%) *#
CustomizationSettingsId&& '
=&&( )#
customizationSettingsId&&* A
}'' 
;'' 
}(( 	
public** 
async** 
Task** 
<**  
CustomUserSettingDto** .
>**. /$
GetCustomizationSettings**0 H
(**H I
int**I L#
customizationSettingsId**M d
,**d e
HttpRequest++ 
request++ 
)++  
{,, 	
var-- 
userId-- 
=-- 
_jwtTokenManager-- )
.--) *
GetUserIdFromToken--* <
(--< =
request--= D
)--D E
;--E F
if.. 
(.. 
userId.. 
==.. 
null.. 
).. 
throw..  %
new..& )
	Exception..* 3
(..3 4
$str..4 D
)..D E
;..E F
var// !
customizationSettings// %
=//& '
await//( -"
_customizationSettings//. D
.//D E$
GetCustomizationSettings//E ]
(//] ^#
customizationSettingsId//^ u
)//u v
;//v w
return11 
new11  
CustomUserSettingDto11 +
{22 
BannerImage33 
=33 !
customizationSettings33 3
.333 4
BannerImage334 ?
,33? @#
CustomizationSettingsId44 '
=44( )!
customizationSettings44* ?
.44? @#
CustomizationSettingsId44@ W
}55 
;55 
}66 	
}77 
}88 �!
�C:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Infrastructure\Implementations\User\BookmarkService.cs
	namespace 	
FanPage
 
. 
Infrastructure  
.  !
Implementations! 0
.0 1
User1 5
{		 
public

 

class

 
BookmarkService

  
:

! "
	IBookmark

# ,
{ 
private 
readonly 
IBookmarkRepository ,
_bookmarkRepository- @
;@ A
private 
readonly 
IJwtTokenManager )
_jwtTokenManager* :
;: ;
private 
readonly 
IFanficRepository *
_fanficRepository+ <
;< =
public 
BookmarkService 
( 
IBookmarkRepository 2
bookmarkRepository3 E
,E F
IJwtTokenManagerG W
jwtTokenManagerX g
,g h
IFanficRepository 
fanficRepository .
). /
{ 	
_bookmarkRepository 
=  !
bookmarkRepository" 4
;4 5
_jwtTokenManager 
= 
jwtTokenManager .
;. /
_fanficRepository 
= 
fanficRepository  0
;0 1
} 	
public 
async 
Task 
< 
bool 
> 
Add  #
(# $
HttpRequest$ /
request0 7
,7 8
int9 <
fanficId= E
)E F
{ 	
var 
userName 
= 
_jwtTokenManager +
.+ , 
GetUserNameFromToken, @
(@ A
requestA H
)H I
;I J
if 
( 
userName 
== 
null  
)  !
throw" '
new( +
	Exception, 5
(5 6
$str6 F
)F G
;G H
var 
fanfic 
= 
await 
_fanficRepository 0
.0 1
GetByIdAsync1 =
(= >
fanficId> F
)F G
;G H
if 
( 
fanfic 
== 
null 
) 
throw  %
new& )
	Exception* 3
(3 4
$str4 F
)F G
;G H
await 
_bookmarkRepository %
.% &
Add& )
() *
userName* 2
,2 3
fanficId4 <
)< =
;= >
return 
true 
; 
}   	
public"" 
async"" 
Task"" 
<"" 
List"" 
<"" 
BookmarkDto"" *
>""* +
>""+ ,
BookmarkList""- 9
(""9 :
HttpRequest"": E
request""F M
)""M N
{## 	
var$$ 
userId$$ 
=$$ 
_jwtTokenManager$$ )
.$$) *
GetUserIdFromToken$$* <
($$< =
request$$= D
)$$D E
;$$E F
var%% 
list%% 
=%% 
await%% 
_bookmarkRepository%% 0
.%%0 1
BookmarkList%%1 =
(%%= >
userId%%> D
)%%D E
;%%E F
return&& 
list&& 
;&& 
}'' 	
public)) 
async)) 
Task)) 
<)) 
bool)) 
>)) 
Delete))  &
())& '
HttpRequest))' 2
request))3 :
,)): ;
int))< ?
fanficId))@ H
)))H I
{** 	
var++ 
userId++ 
=++ 
_jwtTokenManager++ )
.++) *
GetUserIdFromToken++* <
(++< =
request++= D
)++D E
;++E F
await,, 
_bookmarkRepository,, %
.,,% &
Delete,,& ,
(,,, -
userId,,- 3
,,,3 4
fanficId,,5 =
),,= >
;,,> ?
return-- 
true-- 
;-- 
}.. 	
}// 
}00 �F
C:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Infrastructure\Implementations\User\AuthService.cs
	namespace

 	
FanPage


 
.

 
Infrastructure

  
.

  !
Implementations

! 0
.

0 1
User

1 5
{ 
public 

class 
AuthService 
: 
IAuth $
{ 
private 
readonly 
IJwtTokenManager )
_jwtTokenManager* :
;: ;
private 
readonly 
SignInManager &
<& '
Domain' -
.- .
Account. 5
.5 6
Entities6 >
.> ?
User? C
>C D
_signInManagerE S
;S T
private 
readonly 
IdentityUserManager ,
_userManager- 9
;9 :
public 
AuthService 
( 
IJwtTokenManager +
jwtTokenManager, ;
,; <
SignInManager= J
<J K
DomainK Q
.Q R
AccountR Y
.Y Z
EntitiesZ b
.b c
Userc g
>g h
signInManageri v
,v w
IdentityUserManager 
userManager  +
)+ ,
{ 	
_jwtTokenManager 
= 
jwtTokenManager .
;. /
_signInManager 
= 
signInManager *
;* +
_userManager 
= 
userManager &
;& '
} 	
public 
async 
Task 
< 
LogInResponseDto *
>* +
LogIn, 1
(1 2
AuthDto2 9
authDto: A
)A B
{ 	
var 
user 
= 
await 
_userManager )
.) *
FindByEmailAsync* :
(: ;
authDto; B
.B C
EmailC H
)H I
;I J
var   
userRole   
=   
await    
_userManager  ! -
.  - .
GetRolesAsync  . ;
(  ; <
user  < @
)  @ A
;  A B
if## 
(## 
user## 
is## 
null## 
)## 
throw$$ 
new$$ 
LogInException$$ (
($$( )
$str$$) B
)$$B C
;$$C D
var&& 
result&& 
=&& 
await&& 
_signInManager&& -
.&&- .$
CheckPasswordSignInAsync&&. F
(&&F G
user&&G K
,&&K L
authDto&&M T
.&&T U
Password&&U ]
,&&] ^
false&&_ d
)&&d e
;&&e f
if(( 
((( 
!(( 
result(( 
.(( 
	Succeeded(( !
)((! "
throw)) 
new)) 
LogInException)) (
())( )
$str))) B
)))B C
;))C D
var++ 
token++ 
=++ 
await++ 
_jwtTokenManager++ .
.++. /
GenerateToken++/ <
(++< =
user++= A
)++A B
;++B C
return,, 
new,, 
LogInResponseDto,, '
{-- 
Id.. 
=.. 
user.. 
... 
Id.. 
,.. 
Email// 
=// 
user// 
.// 
Email// "
,//" #
Name00 
=00 
user00 
.00 
UserName00 $
,00$ %
Token11 
=11 
token11 
,11 
Role22 
=22 
userRole22 
.22  
FirstOrDefault22  .
(22. /
)22/ 0
,220 1
WhoBan33 
=33 
user33 
.33 
WhoBan33 $
,33$ %

UserAvatar44 
=44 
user44 !
.44! "

UserAvatar44" ,
,44, -
LifeTimeToken55 
=55 
DateTime55  (
.55( )
UtcNow55) /
.55/ 0
AddDays550 7
(557 8
$num558 9
)559 :
}66 
;66 
}77 	
public99 
async99 
Task99 
LogOut99  
(99  !
HttpRequest99! ,
request99- 4
)994 5
{:: 	
var<< 
token<< 
=<< 
_jwtTokenManager<< (
.<<( )
GetTokenFromHeader<<) ;
(<<; <
request<<< C
)<<C D
;<<D E
var>> 
userId>> 
=>> 
_jwtTokenManager>> )
.>>) *
GetUserIdFromToken>>* <
(>>< =
request>>= D
)>>D E
;>>E F
var?? 
user?? 
=?? 
await?? 
_userManager?? )
.??) *
FindByIdAsync??* 7
(??7 8
userId??8 >
)??> ?
;??? @
ifAA 
(AA 
userAA 
!=AA 
nullAA 
)AA 
{BB 
awaitCC 
_signInManagerCC $
.CC$ %
SignOutAsyncCC% 1
(CC1 2
)CC2 3
;CC3 4
}GG 
elseHH 
{II 
throwJJ 
newJJ !
UserNotFoundExceptionJJ /
(JJ/ 0
$strJJ0 @
)JJ@ A
;JJA B
}KK 
}LL 	
publicOO 
asyncOO 
TaskOO 
<OO 
RefreshTokenDtoOO )
>OO) *
RefreshTokenOO+ 7
(OO7 8
HttpRequestOO8 C
requestOOD K
)OOK L
{PP 	
varQQ 
tokenQQ 
=QQ 
_jwtTokenManagerQQ (
.QQ( )
GetTokenFromHeaderQQ) ;
(QQ; <
requestQQ< C
)QQC D
;QQD E
varSS 
userIdSS 
=SS 
_jwtTokenManagerSS )
.SS) *
GetUserIdFromTokenSS* <
(SS< =
requestSS= D
)SSD E
;SSE F
varTT 
userTT 
=TT 
awaitTT 
_userManagerTT )
.TT) *
FindByIdAsyncTT* 7
(TT7 8
userIdTT8 >
)TT> ?
;TT? @
varWW 
newTokenWW 
=WW 
_jwtTokenManagerWW +
.WW+ ,
RefreshTokenWW, 8
(WW8 9
tokenWW9 >
,WW> ?
userWW@ D
.WWD E
EmailWWE J
,WWJ K
userIdWWL R
)WWR S
;WWS T
returnYY 
newYY 
RefreshTokenDtoYY &
{ZZ 
Token[[ 
=[[ 
newToken[[  
}\\ 
;\\ 
}]] 	
public__ 
async__ 
Task__ 
<__ 
GoogleResponseDto__ +
>__+ ,
GoogleLogin__- 8
(__8 9
string__9 ?
googleToken__@ K
)__K L
{`` 	
varaa 
tokenaa 
=aa 
awaitaa 
_jwtTokenManageraa .
.aa. /
GoogleLoginaa/ :
(aa: ;
googleTokenaa; F
)aaF G
;aaG H
varbb 
emailFromTokenbb 
=bb  
awaitbb! &
_jwtTokenManagerbb' 7
.bb7 8"
DecodeTokenAndGetEmailbb8 N
(bbN O
tokenbbO T
)bbT U
;bbU V
vardd 
userdd 
=dd 
awaitdd 
_userManagerdd )
.dd) *
FindByEmailAsyncdd* :
(dd: ;
emailFromTokendd; I
)ddI J
;ddJ K
varff 
userRoleff 
=ff 
awaitff  
_userManagerff! -
.ff- .
GetRolesAsyncff. ;
(ff; <
userff< @
)ff@ A
;ffA B
returnhh 
newhh 
GoogleResponseDtohh (
{ii 
Idjj 
=jj 
userjj 
.jj 
Idjj 
,jj 
Emailkk 
=kk 
userkk 
.kk 
Emailkk "
,kk" #
Namell 
=ll 
userll 
.ll 
UserNamell $
,ll$ %
Tokenmm 
=mm 
tokenmm 
,mm 
Rolenn 
=nn 
userRolenn 
.nn  
FirstOrDefaultnn  .
(nn. /
)nn/ 0
,nn0 1
WhoBanoo 
=oo 
useroo 
.oo 
WhoBanoo $
,oo$ %

UserAvatarpp 
=pp 
userpp !
.pp! "

UserAvatarpp" ,
,pp, -
LifeTimeTokenqq 
=qq 
DateTimeqq  (
.qq( )
UtcNowqq) /
.qq/ 0
AddDaysqq0 7
(qq7 8
$numqq8 9
)qq9 :
}rr 
;rr 
}ss 	
}tt 
}uu ֒
�C:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Infrastructure\Implementations\User\AdminService.cs
	namespace 	
FanPage
 
. 
Infrastructure  
.  !
Implementations! 0
.0 1
User1 5
;5 6
public 
class 
AdminService 
: 
IAdmin "
{ 
private 
readonly 
UserManager  
<  !
Domain! '
.' (
Account( /
./ 0
Entities0 8
.8 9
User9 =
>= >
_userManager? K
;K L
private 
readonly 
IJwtTokenManager %
_jwtTokenManager& 6
;6 7
private 
readonly 
ITagRepository #
_tagRepository$ 2
;2 3
public 

AdminService 
( 
UserManager #
<# $
Domain$ *
.* +
Account+ 2
.2 3
Entities3 ;
.; <
User< @
>@ A
userManagerB M
,M N
IJwtTokenManagerO _
jwtTokenManager` o
,o p
ITagRepository 
tagRepository $
)$ %
{ 
_userManager 
= 
userManager "
;" #
_jwtTokenManager 
= 
jwtTokenManager *
;* +
_tagRepository 
= 
tagRepository &
;& '
} 
public 

async 
Task 
< 
bool 
> 
Delete "
(" #
string# )
Id* ,
), -
{ 
var 
userToDelete 
= 
await  
_userManager! -
.- .
FindByIdAsync. ;
(; <
Id< >
)> ?
;? @
if 

( 
userToDelete 
== 
null  
)  !
{ 	
throw   
new   !
UserNotFoundException   +
(  + ,
$str  , <
)  < =
;  = >
}!! 	
var## 
result## 
=## 
await## 
_userManager## '
.##' (
DeleteAsync##( 3
(##3 4
userToDelete##4 @
)##@ A
;##A B
return%% 
result%% 
.%% 
	Succeeded%% 
?%%  !
true%%" &
:%%' (
throw%%) .
new%%/ 2
UserDeleteException%%3 F
(%%F G
$str%%G Y
)%%Y Z
;%%Z [
}&& 
public(( 

async(( 
Task(( 
<(( 
bool(( 
>(( 
Ban(( 
(((  
BanDto((  &
user((' +
,((+ ,
HttpRequest((- 8
request((9 @
)((@ A
{)) 
var** 
userToBlock** 
=** 
await++ 
_userManager++ 
.++ 
FindByIdAsync++ ,
(++, -
user++- 1
.++1 2
Id++2 4
??++5 7
throw++8 =
new++> A%
InvalidOperationException++B [
(++[ \
$str++\ l
)++l m
)++m n
;++n o
var,, 
admin,, 
=,, 
_jwtTokenManager,, $
.,,$ % 
GetUserNameFromToken,,% 9
(,,9 :
request,,: A
),,A B
;,,B C
if-- 

(-- 
userToBlock-- 
==-- 
null-- 
)--  
{.. 	
throw// 
new// !
UserNotFoundException// +
(//+ ,
$str//, <
)//< =
;//= >
}00 	
var22 
lockoutEndDate22 
=22 
DateTime22 %
.22% &
UtcNow22& ,
.22, -
AddDays22- 4
(224 5
(225 6
double226 <
)22< =
user22= A
.22A B
days22B F
!22F G
)22G H
;22H I
var33 
result33 
=33 
await33 
_userManager33 '
.33' ("
SetLockoutEndDateAsync33( >
(33> ?
userToBlock33? J
,33J K
lockoutEndDate33L Z
)33Z [
;33[ \
userToBlock44 
.44 
WhoBan44 
=44 
admin44 "
;44" #
await55 
_userManager55 
.55 
UpdateAsync55 &
(55& '
userToBlock55' 2
)552 3
;553 4
return66 
result66 
.66 
	Succeeded66 
?66  !
true66" &
:66' (
throw66) .
new66/ 2%
InvalidOperationException663 L
(66L M
$str66M b
)66b c
;66c d
}77 
public99 

async99 
Task99 
<99 
bool99 
>99 
Unban99 !
(99! "
string99" (
id99) +
)99+ ,
{:: 
var;; 
userToUnblock;; 
=;; 
await;; !
_userManager;;" .
.;;. /
FindByIdAsync;;/ <
(;;< =
id;;= ?
);;? @
;;;@ A
if== 

(== 
userToUnblock== 
==== 
null== !
)==! "
{>> 	
throw?? 
new?? !
UserNotFoundException?? +
(??+ ,
$str??, <
)??< =
;??= >
}@@ 	
varBB 
resultBB 
=BB 
awaitBB 
_userManagerBB '
.BB' ("
SetLockoutEndDateAsyncBB( >
(BB> ?
userToUnblockBB? L
,BBL M
nullBBN R
)BBR S
;BBS T
returnDD 
resultDD 
.DD 
	SucceededDD 
?DD  !
trueDD" &
:DD' (
throwDD) .
newDD/ 2%
InvalidOperationExceptionDD3 L
(DDL M
$strDDM d
)DDd e
;DDe f
}EE 
publicGG 

asyncGG 
TaskGG 
<GG 
IdentityResultGG $
>GG$ %

ChangeRoleGG& 0
(GG0 1
ChangeRoleDtoGG1 >
userGG? C
)GGC D
{HH 
varII 
userForChangeRoleII 
=II 
awaitJJ 
_userManagerJJ 
.JJ 
FindByIdAsyncJJ ,
(JJ, -
userJJ- 1
.JJ1 2
IdJJ2 4
??JJ5 7
throwJJ8 =
newJJ> A%
InvalidOperationExceptionJJB [
(JJ[ \
$strJJ\ l
)JJl m
)JJm n
;JJn o
ifLL 

(LL 
userLL 
==LL 
nullLL 
)LL 
{MM 	
throwNN 
newNN !
UserNotFoundExceptionNN +
(NN+ ,
$strNN, <
)NN< =
;NN= >
}OO 	
varQQ 
rolesQQ 
=QQ 
awaitQQ 
_userManagerQQ &
.QQ& '
GetRolesAsyncQQ' 4
(QQ4 5
userForChangeRoleQQ5 F
??QQG I
throwRR5 :
newRR; >%
InvalidOperationExceptionRR? X
(RRX Y
$strRRY i
)RRi j
)RRj k
;RRk l
ifSS 

(SS 
rolesSS 
.SS 
ContainsSS 
(SS 
$strSS "
)SS" #
)SS# $
{TT 	
throwUU 
newUU %
InvalidOperationExceptionUU /
(UU/ 0
$strUU0 Z
)UUZ [
;UU[ \
}VV 	
awaitXX 
_userManagerXX 
.XX  
RemoveFromRolesAsyncXX /
(XX/ 0
userForChangeRoleXX0 A
,XXA B
rolesXXC H
)XXH I
;XXI J
returnYY 
awaitYY 
_userManagerYY !
.YY! "
AddToRoleAsyncYY" 0
(YY0 1
userForChangeRoleYY1 B
,YYB C
userYYD H
.YYH I
NewRoleYYI P
)YYP Q
;YYQ R
}ZZ 
public\\ 

async\\ 
Task\\ 
<\\ 
List\\ 
<\\ "
UserBanInfoResponseDto\\ 1
>\\1 2
>\\2 3
GetUserInBan\\4 @
(\\@ A
)\\A B
{]] 
var^^ 
bannedUsers^^ 
=^^ 
await^^ 
_userManager^^  ,
.^^, -
Users^^- 2
.__ 
Where__ 
(__ 
u__ 
=>__ 
u__ 
.__ 

LockoutEnd__ $
!=__% '
null__( ,
&&__- /
u__0 1
.__1 2

LockoutEnd__2 <
>__= >
DateTime__? G
.__G H
Now__H K
)__K L
.`` 
Select`` 
(`` 
u`` 
=>`` 
new`` "
UserBanInfoResponseDto`` 3
{aa 
Idbb 
=bb 
ubb 
.bb 
Idbb 
,bb 
Namecc 
=cc 
ucc 
.cc 
UserNamecc !
,cc! "
BanTimedd 
=dd 
udd 
.dd 

LockoutEnddd &
,dd& '
	AdminNameee 
=ee 
uee 
.ee 
WhoBanee $
}ff 
)ff 
.gg 
ToListAsyncgg 
(gg 
)gg 
;gg 
returnhh 
bannedUsershh 
;hh 
}ii 
publickk 

asynckk 
Taskkk 
<kk 
Listkk 
<kk 
UserInfoResponseDtokk .
>kk. /
>kk/ 0
AllUserskk1 9
(kk9 :
)kk: ;
{ll 
varmm 
usersmm 
=mm 
awaitmm 
_userManagermm &
.mm& '
Usersmm' ,
.mm, -
ToListAsyncmm- 8
(mm8 9
)mm9 :
;mm: ;
varnn 
userDtosnn 
=nn 
usersnn 
.nn 
Selectnn #
(nn# $
unn$ %
=>nn& (
newnn) ,
UserInfoResponseDtonn- @
{nnA B
IdnnC E
=nnF G
unnH I
.nnI J
IdnnJ L
,nnL M
NamennN R
=nnS T
unnU V
.nnV W
UserNamennW _
}nn` a
)nna b
.nnb c
ToListnnc i
(nni j
)nnj k
;nnk l
returnoo 
userDtosoo 
;oo 
}pp 
publicrr 

asyncrr 
Taskrr 
<rr 
boolrr 
>rr 

ApproveTagrr &
(rr& '
intrr' *
tagIdrr+ 0
,rr0 1
HttpRequestrr2 =
requestrr> E
)rrE F
{ss 
vartt 
usertt 
=tt 
_jwtTokenManagertt #
.tt# $ 
GetUserNameFromTokentt$ 8
(tt8 9
requesttt9 @
)tt@ A
;ttA B
varuu 
userForChangeRoleuu 
=uu 
awaituu  %
_userManageruu& 2
.uu2 3
FindByNameAsyncuu3 B
(uuB C
useruuC G
)uuG H
;uuH I
ifww 

(ww 
userForChangeRoleww 
!=ww  
nullww! %
)ww% &
{xx 	
varyy 
rolesyy 
=yy 
awaityy 
_userManageryy *
.yy* +
GetRolesAsyncyy+ 8
(yy8 9
userForChangeRoleyy9 J
)yyJ K
;yyK L
ifzz 
(zz 
roleszz 
.zz 
Containszz 
(zz 
$strzz &
)zz& '
)zz' (
{{{ 
throw|| 
new|| %
InvalidOperationException|| 3
(||3 4
$str||4 ^
)||^ _
;||_ `
}}} 
}~~ 	
var
�� 
tag
�� 
=
�� 
_tagRepository
��  
.
��  !

ApproveTag
��! +
(
��+ ,
tagId
��, 1
)
��1 2
;
��2 3
return
�� 
await
�� 
tag
�� 
;
�� 
}
�� 
public
�� 

async
�� 
Task
�� 
<
�� 
List
�� 
<
�� 
TagDto
�� !
>
��! "
>
��" # 
GetNotApprovedTags
��$ 6
(
��6 7
)
��7 8
{
�� 
var
�� 
tags
�� 
=
�� 
await
�� 
_tagRepository
�� '
.
��' ( 
GetNotApprovedTags
��( :
(
��: ;
)
��; <
;
��< =
return
�� 
tags
�� 
.
�� 
Select
�� 
(
�� 
tag
�� 
=>
�� !
new
��" %
TagDto
��& ,
{
�� 	
TagId
�� 
=
�� 
tag
�� 
.
�� 
TagId
�� 
,
�� 
Name
�� 
=
�� 
tag
�� 
.
�� 
Name
�� 
}
�� 	
)
��	 

.
��
 
ToList
�� 
(
�� 
)
�� 
;
�� 
}
�� 
public
�� 

async
�� 
Task
�� 
<
�� !
UserInfoResponseDto
�� )
>
��) *
GetAdminAsync
��+ 8
(
��8 9
HttpRequest
��9 D
request
��E L
)
��L M
{
�� 
var
�� 
user
�� 
=
�� 
_jwtTokenManager
�� #
.
��# $"
GetUserNameFromToken
��$ 8
(
��8 9
request
��9 @
)
��@ A
;
��A B
var
�� 
userRole
�� 
=
�� 
await
�� 
_userManager
�� )
.
��) *
FindByNameAsync
��* 9
(
��9 :
user
��: >
)
��> ?
;
��? @
var
�� 
admin
�� 
=
�� 
await
�� 
_userManager
�� &
.
��& '
GetRolesAsync
��' 4
(
��4 5
userRole
��5 =
)
��= >
;
��> ?
if
�� 

(
�� 
admin
�� 
.
�� 
Contains
�� 
(
�� 
$str
�� "
)
��" #
)
��# $
{
�� 	
throw
�� 
new
�� '
InvalidOperationException
�� /
(
��/ 0
$str
��0 I
)
��I J
;
��J K
}
�� 	
return
�� 
new
�� !
UserInfoResponseDto
�� &
{
�� 	
Name
�� 
=
�� 
userRole
�� 
.
�� 
UserName
�� $
,
��$ %
Email
�� 
=
�� 
userRole
�� 
.
�� 
Email
�� "
,
��" #
PhoneNumber
�� 
=
�� 
userRole
�� "
.
��" #
PhoneNumber
��# .
,
��. /
Role
�� 
=
�� 
admin
�� 
.
�� 
FirstOrDefault
�� '
(
��' (
)
��( )
}
�� 	
;
��	 

}
�� 
public
�� 

async
�� 
Task
�� 
<
�� !
UserInfoResponseDto
�� )
>
��) *
GetModeratorAsync
��+ <
(
��< =
HttpRequest
��= H
request
��I P
)
��P Q
{
�� 
var
�� 
user
�� 
=
�� 
_jwtTokenManager
�� #
.
��# $"
GetUserNameFromToken
��$ 8
(
��8 9
request
��9 @
)
��@ A
;
��A B
var
�� 
userRole
�� 
=
�� 
await
�� 
_userManager
�� )
.
��) *
FindByNameAsync
��* 9
(
��9 :
user
��: >
)
��> ?
;
��? @
var
�� 
	moderator
�� 
=
�� 
await
�� 
_userManager
�� *
.
��* +
GetRolesAsync
��+ 8
(
��8 9
userRole
��9 A
)
��A B
;
��B C
if
�� 

(
�� 
	moderator
�� 
.
�� 
Contains
�� 
(
�� 
$str
�� *
)
��* +
)
��+ ,
{
�� 	
throw
�� 
new
�� '
InvalidOperationException
�� /
(
��/ 0
$str
��0 I
)
��I J
;
��J K
}
�� 	
return
�� 
new
�� !
UserInfoResponseDto
�� &
{
�� 	
Name
�� 
=
�� 
userRole
�� 
.
�� 
UserName
�� $
,
��$ %
Email
�� 
=
�� 
userRole
�� 
.
�� 
Email
�� "
,
��" #
PhoneNumber
�� 
=
�� 
userRole
�� "
.
��" #
PhoneNumber
��# .
,
��. /
Role
�� 
=
�� 
	moderator
�� 
.
�� 
FirstOrDefault
�� +
(
��+ ,
)
��, -
}
�� 	
;
��	 

}
�� 
public
�� 

async
�� 
Task
�� 
<
�� !
UserInfoResponseDto
�� )
>
��) *
GetUserRoleAsync
��+ ;
(
��; <
string
��< B
userName
��C K
)
��K L
{
�� 
var
�� 
userRole
�� 
=
�� 
await
�� 
_userManager
�� )
.
��) *
FindByNameAsync
��* 9
(
��9 :
userName
��: B
)
��B C
;
��C D
var
�� 
role
�� 
=
�� 
await
�� 
_userManager
�� %
.
��% &
GetRolesAsync
��& 3
(
��3 4
userRole
��4 <
??
��= ?
throw
��@ E
new
��F I'
InvalidOperationException
��J c
(
��c d
$str
��d u
)
��u v
)
��v w
;
��w x
return
�� 
new
�� !
UserInfoResponseDto
�� &
{
�� 	
Name
�� 
=
�� 
userRole
�� 
.
�� 
UserName
�� $
,
��$ %
Email
�� 
=
�� 
userRole
�� 
.
�� 
Email
�� "
,
��" #
PhoneNumber
�� 
=
�� 
userRole
�� "
.
��" #
PhoneNumber
��# .
,
��. /
Role
�� 
=
�� 
role
�� 
.
�� 
FirstOrDefault
�� &
(
��& '
)
��' (
}
�� 	
;
��	 

}
�� 
}�� ��
�C:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Infrastructure\Implementations\User\AccountServiсe.cs
	namespace 	
FanPage
 
. 
Infrastructure  
.  !
Implementations! 0
.0 1
User1 5
{ 
public 

class 
AccountServiсe 
:  !
IAccount" *
{ 
private 
readonly 
IdentityUserManager ,
_userManager- 9
;9 :
private 
readonly 
IEmailService &
_emailService' 4
;4 5
private 
readonly 
SignInManager &
<& '
Domain' -
.- .
Account. 5
.5 6
Entities6 >
.> ?
User? C
>C D
_signInManagerE S
;S T
private 
readonly 
IPasswordManager )
_passwordManager* :
;: ;
private 
readonly 
IJwtTokenManager )
_jwtTokenManager* :
;: ;
private 
readonly ,
 ICustomizationSettingsRepository 9"
_customizationSettings: P
;P Q
public 
AccountServiсe 
( ,
 ICustomizationSettingsRepository ?!
customizationSettings@ U
,U V
IPasswordManager 
passwordManager ,
,, -
SignInManager. ;
<; <
Domain< B
.B C
AccountC J
.J K
EntitiesK S
.S T
UserT X
>X Y
signInManagerZ g
,g h
IJwtTokenManager   
jwtTokenManager   ,
,  , -
IdentityUserManager!! 
identityUser!!  ,
,!!, -
IEmailService!!. ;
emailService!!< H
)!!H I
{"" 	
_userManager## 
=## 
identityUser## '
;##' (
_emailService$$ 
=$$ 
emailService$$ (
;$$( )
_jwtTokenManager%% 
=%% 
jwtTokenManager%% .
;%%. /
_signInManager&& 
=&& 
signInManager&& *
;&&* +
_passwordManager'' 
='' 
passwordManager'' .
;''. /"
_customizationSettings(( "
=((# $!
customizationSettings((% :
;((: ;
})) 	
public++ 
async++ 
Task++ 
ConfirmEmail++ &
(++& '
ConfirmEmailDto++' 6
confirmEmail++7 C
)++C D
{,, 	
var-- 
user-- 
=-- 
await-- 
_userManager-- )
.--) *
FindByEmailAsync--* :
(--: ;
confirmEmail--; G
.--G H
Email--H M
)--M N
;--N O
if// 
(// 
user// 
is// 
null// 
)// 
{00 
throw11 
new11 !
UserNotFoundException11 /
(11/ 0
$str110 @
)11@ A
;11A B
}22 
var44 

validToken44 
=44 
confirmEmail44 )
.44) *
Token44* /
.44/ 0
Replace440 7
(447 8
$str448 ;
,44; <
$str44= @
)44@ A
;44A B
var66 
confirmResult66 
=66 
await66  %
_userManager66& 2
.662 3
ConfirmEmailAsync663 D
(66D E
user66E I
,66I J

validToken66K U
)66U V
;66V W
if88 
(88 
!88 
confirmResult88 
.88 
	Succeeded88 (
)88( )
{99 
throw:: 
new:: 
AggregateException:: ,
(::, -
confirmResult;; !
.;;! "
Errors;;" (
.;;( )
Select;;) /
(;;/ 0
s;;0 1
=>;;2 4
new;;5 8"
ResetPasswordException;;9 O
(;;O P
s;;P Q
.;;Q R
Description;;R ]
);;] ^
);;^ _
);;_ `
;;;` a
}<< 
}== 	
public?? 
async?? 
Task?? 
<?? 
LogInResponseDto?? *
>??* +
GetUserInfo??, 7
(??7 8
string??8 >
userName??? G
)??G H
{@@ 	
varAA 
userAA 
=AA 
awaitAA 
_userManagerAA )
.AA) *
FindByNameAsyncAA* 9
(AA9 :
userNameAA: B
)AAB C
;AAC D
ifCC 
(CC 
userCC 
isCC 
nullCC 
)CC 
throwDD 
newDD !
UserNotFoundExceptionDD /
(DD/ 0
$strDD0 @
)DD@ A
;DDA B
varFF 
roleFF 
=FF 
awaitFF 
_userManagerFF )
.FF) *
GetRolesAsyncFF* 7
(FF7 8
userFF8 <
)FF< =
;FF= >
varHH 
tokenHH 
=HH 
awaitHH 
_jwtTokenManagerHH .
.HH. /
GenerateTokenHH/ <
(HH< =
userHH= A
)HHA B
;HHB C
returnII 
newII 
LogInResponseDtoII '
{JJ 
IdKK 
=KK 
userKK 
.KK 
IdKK 
,KK 
EmailLL 
=LL 
userLL 
.LL 
EmailLL "
,LL" #
NameMM 
=MM 
userMM 
.MM 
UserNameMM $
,MM$ %
TokenNN 
=NN 
tokenNN 
,NN 
RoleOO 
=OO 
roleOO 
.OO 
FirstOrDefaultOO *
(OO* +
)OO+ ,
,OO, -
WhoBanPP 
=PP 
userPP 
.PP 
WhoBanPP $
,PP$ %

UserAvatarQQ 
=QQ 
userQQ !
.QQ! "

UserAvatarQQ" ,
,QQ, -
}RR 
;RR 
}SS 	
publicUU 
asyncUU 
TaskUU 
ChangeEmailUU %
(UU% &
ChangeEmailDtoUU& 4
changeEmailUU5 @
)UU@ A
{VV 	
varWW 
userWW 
=WW 
awaitWW 
_userManagerWW )
.WW) *
FindByEmailAsyncWW* :
(WW: ;
changeEmailWW; F
.WWF G
EmailWWG L
)WWL M
;WWM N
ifYY 
(YY 
userYY 
isYY 
nullYY 
)YY 
throwZZ 
newZZ !
UserNotFoundExceptionZZ /
(ZZ/ 0
$strZZ0 @
)ZZ@ A
;ZZA B
var\\ 

validToken\\ 
=\\ 
changeEmail\\ (
.\\( )
Token\\) .
.\\. /
Replace\\/ 6
(\\6 7
$str\\7 :
,\\: ;
$str\\< ?
)\\? @
;\\@ A
var]] 
email]] 
=]] 
await]] 
_userManager]] *
.]]* +
ChangeEmailAsync]]+ ;
(]]; <
user]]< @
,]]@ A
changeEmail]]B M
.]]M N
NewEmail]]N V
,]]V W

validToken]]X b
)]]b c
;]]c d
if__ 
(__ 
!__ 
email__ 
.__ 
	Succeeded__  
)__  !
throw`` 
new`` 
AggregateException`` ,
(``, -
emailaa 
.aa 
Errorsaa  
.aa  !
Selectaa! '
(aa' (
saa( )
=>aa* ,
newaa- 0"
ResetPasswordExceptionaa1 G
(aaG H
saaH I
.aaI J
DescriptionaaJ U
)aaU V
)aaV W
)aaW X
;aaX Y
}bb 	
publicdd 
asyncdd 
Taskdd  
RequestToChangeEmaildd .
(dd. /#
RequestToChangeEmailDtodd/ F
changeEmailddG R
,ddR S
HttpRequestddT _
requestdd` g
)ddg h
{ee 	
varff 
idFromTokenff 
=ff 
_jwtTokenManagerff .
.ff. /
GetUserIdFromTokenff/ A
(ffA B
requestffB I
)ffI J
;ffJ K
vargg 
usergg 
=gg 
awaitgg 
_userManagergg )
.gg) *
FindByIdAsyncgg* 7
(gg7 8
idFromTokengg8 C
)ggC D
;ggD E
ifii 
(ii 
userii 
isii 
nullii 
)ii 
throwjj 
newjj !
UserNotFoundExceptionjj /
(jj/ 0
$strjj0 @
)jj@ A
;jjA B
ifll 
(ll 
userll 
.ll 
Emailll 
==ll 
changeEmailll )
.ll) *
NewEmailll* 2
)ll2 3
throwmm 
newmm 
	Exceptionmm #
(mm# $
$strmm$ ^
)mm^ _
;mm_ `
varoo 
changeEmailTokenoo  
=oo! "
awaitoo# (
_userManageroo) 5
.oo5 6)
GenerateChangeEmailTokenAsyncoo6 S
(ooS T
userooT X
,ooX Y
changeEmailooZ e
.ooe f
NewEmailoof n
)oon o
;ooo p
varqq 
changeEmailUrlqq 
=qq  
Urlqq! $
.qq$ %
Combineqq% ,
(qq, -
changeEmailrr 
.rr 
ChangeEmailUrlrr *
.rr* +
BaseAddressrr+ 6
,rr6 7
changeEmailss 
.ss 
ChangeEmailUrlss *
.ss* +
ControllerRoutess+ :
,ss: ;
changeEmailtt 
.tt 
ChangeEmailUrltt *
.tt* +
MethodRoutett+ 6
,tt6 7
$"uu 
$struu 
{uu 
useruu 
.uu 
Emailuu $
}uu$ %
$struu% /
{uu/ 0
changeEmailuu0 ;
.uu; <
NewEmailuu< D
}uuD E
$struuE L
{uuL M
changeEmailTokenuuM ]
}uu] ^
"uu^ _
)vv 
;vv 
varxx 
emailxx 
=xx 
newxx 
EmailRequestxx (
{yy 
Subjectzz 
=zz 
$strzz #
,zz# $
Html{{ 
={{ 
$"{{ 
$str{{ ,
{{{, -
changeEmailUrl{{- ;
}{{; <
"{{< =
,{{= >
EmailTo|| 
=|| 
user|| 
.|| 
Email|| $
}}} 
;}} 
await 
_emailService 
.  
	SendAsync  )
() *
email* /
)/ 0
;0 1
}
�� 	
public
�� 
async
�� 
Task
�� 
ChangePassword
�� (
(
��( )
ChangePasswordDto
��) :
changePassword
��; I
,
��I J
HttpRequest
��K V
request
��W ^
)
��^ _
{
�� 	
var
�� 
idFromToken
�� 
=
�� 
_jwtTokenManager
�� .
.
��. / 
GetUserIdFromToken
��/ A
(
��A B
request
��B I
)
��I J
;
��J K
var
�� 
user
�� 
=
�� 
await
�� 
_userManager
�� )
.
��) *
FindByIdAsync
��* 7
(
��7 8
idFromToken
��8 C
)
��C D
;
��D E
if
�� 
(
�� 
user
�� 
is
�� 
null
�� 
)
�� 
throw
�� 
new
�� #
UserNotFoundException
�� /
(
��/ 0
$str
��0 @
)
��@ A
;
��A B
var
�� !
checkPasswordResult
�� #
=
��$ %
await
�� 
_signInManager
�� $
.
��$ %&
CheckPasswordSignInAsync
��% =
(
��= >
user
��> B
,
��B C
changePassword
��D R
.
��R S
Password
��S [
,
��[ \
false
��] b
)
��b c
;
��c d
if
�� 
(
�� 
!
�� !
checkPasswordResult
�� $
.
��$ %
	Succeeded
��% .
)
��. /
throw
�� 
new
�� &
InvalidPasswordException
�� 2
(
��2 3
$str
��3 E
)
��E F
;
��F G
var
�� "
changePasswordResult
�� $
=
��% &
await
�� 
_userManager
�� "
.
��" #!
ChangePasswordAsync
��# 6
(
��6 7
user
��7 ;
,
��; <
changePassword
��= K
.
��K L
Password
��L T
,
��T U
changePassword
��V d
.
��d e
NewPassword
��e p
)
��p q
;
��q r
if
�� 
(
�� 
!
�� "
changePasswordResult
�� %
.
��% &
	Succeeded
��& /
)
��/ 0
throw
�� 
new
��  
AggregateException
�� ,
(
��, -"
changePasswordResult
�� (
.
��( )
Errors
��) /
.
��/ 0
Select
��0 6
(
��6 7
s
��7 8
=>
��9 ;
new
��< ?%
ChangePasswordException
��@ W
(
��W X
s
��X Y
.
��Y Z
Description
��Z e
)
��e f
)
��f g
)
�� 
;
�� 
var
�� 
email
�� 
=
�� 
new
�� 
EmailRequest
�� (
{
�� 
Subject
�� 
=
�� 
$str
�� #
,
��# $
Html
�� 
=
�� 
$str
�� (
,
��( )
EmailTo
�� 
=
�� 
user
�� 
.
�� 
Email
�� $
}
�� 
;
�� 
await
�� 
_emailService
�� 
.
��  
	SendAsync
��  )
(
��) *
email
��* /
)
��/ 0
;
��0 1
}
�� 	
public
�� 
async
�� 
Task
�� $
RequestRestorePassword
�� 0
(
��0 1'
RequestRestorePasswordDto
��1 J$
requestRestorePassword
��K a
)
��a b
{
�� 	
var
�� 
user
�� 
=
�� 
await
�� 
_userManager
�� )
.
��) *
FindByEmailAsync
��* :
(
��: ;$
requestRestorePassword
��; Q
.
��Q R
Email
��R W
)
��W X
;
��X Y
if
�� 
(
�� 
user
�� 
is
�� 
null
�� 
)
�� 
throw
�� 
new
�� #
UserNotFoundException
�� /
(
��/ 0
$str
��0 @
)
��@ A
;
��A B
var
�� 
resetPassToken
�� 
=
��  
await
��! &
_userManager
��' 3
.
��3 4-
GeneratePasswordResetTokenAsync
��4 S
(
��S T
user
��T X
)
��X Y
;
��Y Z
var
�� 
resetPassUrl
�� 
=
�� 
Url
�� "
.
��" #
Combine
��# *
(
��* +$
requestRestorePassword
�� &
.
��& ' 
RestorePasswordUrl
��' 9
.
��9 :
BaseAddress
��: E
,
��E F$
requestRestorePassword
�� &
.
��& ' 
RestorePasswordUrl
��' 9
.
��9 :
ControllerRoute
��: I
,
��I J$
requestRestorePassword
�� &
.
��& ' 
RestorePasswordUrl
��' 9
.
��9 :
MethodRoute
��: E
,
��E F
$"
�� 
$str
�� 
{
�� 
user
�� 
.
�� 
Email
�� $
}
��$ %
$str
��% ,
{
��, -
resetPassToken
��- ;
}
��; <
"
��< =
)
�� 
;
�� 
var
�� 
email
�� 
=
�� 
new
�� 
EmailRequest
�� (
{
�� 
Subject
�� 
=
�� 
$str
�� #
,
��# $
Html
�� 
=
�� 
$"
�� 
$str
�� /
{
��/ 0
resetPassUrl
��0 <
}
��< =
"
��= >
,
��> ?
EmailTo
�� 
=
�� 
user
�� 
.
�� 
Email
�� $
}
�� 
;
�� 
await
�� 
_emailService
�� 
.
��  
	SendAsync
��  )
(
��) *
email
��* /
)
��/ 0
;
��0 1
}
�� 	
public
�� 
async
�� 
Task
�� 
RestorePassword
�� )
(
��) * 
RestorePasswordDto
��* <
restore
��= D
)
��D E
{
�� 	
var
�� 
user
�� 
=
�� 
await
�� 
_userManager
�� )
.
��) *
FindByEmailAsync
��* :
(
��: ;
restore
��; B
.
��B C
Email
��C H
)
��H I
;
��I J
if
�� 
(
�� 
user
�� 
is
�� 
null
�� 
)
�� 
throw
�� 
new
�� #
UserNotFoundException
�� /
(
��/ 0
$str
��0 @
)
��@ A
;
��A B
var
�� 
newPassword
�� 
=
�� 
_passwordManager
�� .
.
��. /
GetNewPassword
��/ =
(
��= >
)
��> ?
;
��? @
var
�� 

validToken
�� 
=
�� 
restore
�� $
.
��$ %
Token
��% *
.
��* +
Replace
��+ 2
(
��2 3
$str
��3 6
,
��6 7
$str
��8 ;
)
��; <
;
��< =
var
�� 
resetPassword
�� 
=
�� 
await
��  %
_userManager
��& 2
.
��2 3 
ResetPasswordAsync
��3 E
(
��E F
user
��F J
,
��J K

validToken
��L V
,
��V W
newPassword
��X c
)
��c d
;
��d e
if
�� 
(
�� 
!
�� 
resetPassword
�� 
.
�� 
	Succeeded
�� (
)
��( )
throw
�� 
new
��  
AggregateException
�� ,
(
��, -
resetPassword
�� !
.
��! "
Errors
��" (
.
��( )
Select
��) /
(
��/ 0
s
��0 1
=>
��2 4
new
��5 8$
ResetPasswordException
��9 O
(
��O P
s
��P Q
.
��Q R
Description
��R ]
)
��] ^
)
��^ _
)
��_ `
;
��` a
var
�� 
email
�� 
=
�� 
new
�� 
EmailRequest
�� (
{
�� 
Subject
�� 
=
�� 
$str
�� #
,
��# $
Html
�� 
=
�� 
$"
�� 
$str
�� (
{
��( )
newPassword
��) 4
}
��4 5
"
��5 6
,
��6 7
EmailTo
�� 
=
�� 
user
�� 
.
�� 
Email
�� $
}
�� 
;
�� 
await
�� 
_emailService
�� 
.
��  
	SendAsync
��  )
(
��) *
email
��* /
)
��/ 0
;
��0 1
}
�� 	
public
�� 
async
�� 
Task
�� 
Registration
�� &
(
��& '
RegistrationDto
��' 6
registration
��7 C
)
��C D
{
�� 	
var
�� $
customizationSettingId
�� &
=
��' (
await
��) .$
_customizationSettings
��/ E
.
��E F)
CreateCustomizationSettings
��F a
(
��a b
)
��b c
;
��c d
var
�� 
user
�� 
=
�� 
new
�� 
Domain
�� !
.
��! "
Account
��" )
.
��) *
Entities
��* 2
.
��2 3
User
��3 7
{
�� 
Email
�� 
=
�� 
registration
�� $
.
��$ %
Email
��% *
,
��* +
UserName
�� 
=
�� 
registration
�� '
.
��' (
UserName
��( 0
,
��0 1%
CustomizationSettingsId
�� '
=
��( )$
customizationSettingId
��* @
,
��@ A
WhoBan
�� 
=
�� 
$str
�� 
}
�� 
;
�� 
if
�� 
(
�� 
registration
�� 
.
�� 
UserName
�� %
!=
��& (
null
��) -
&&
��. 0
await
��1 6
_userManager
��7 C
.
��C D
FindByNameAsync
��D S
(
��S T
registration
��T `
.
��` a
UserName
��a i
)
��i j
!=
��k m
null
��n r
)
��r s
{
�� 
throw
�� 
new
�� !
UserCreateException
�� -
(
��- .
$str
��. V
)
��V W
;
��W X
}
�� 
if
�� 
(
�� 
registration
�� 
.
�� 
Email
�� "
!=
��# %
null
��& *
&&
��+ -
await
��. 3
_userManager
��4 @
.
��@ A
FindByEmailAsync
��A Q
(
��Q R
registration
��R ^
.
��^ _
Email
��_ d
)
��d e
==
��f h
null
��i m
)
��m n
{
�� 
var
�� 
createResult
��  
=
��! "
await
��# (
_userManager
��) 5
.
��5 6
CreateAsync
��6 A
(
��A B
user
��B F
,
��F G
registration
��H T
.
��T U
Password
��U ]
)
��] ^
;
��^ _
if
�� 
(
�� 
!
�� 
createResult
�� !
.
��! "
	Succeeded
��" +
)
��+ ,
{
�� 
throw
�� 
new
��  
AggregateException
�� 0
(
��0 1
createResult
��1 =
.
��= >
Errors
��> D
.
��D E
Select
��E K
(
��K L
s
��L M
=>
��N P
new
�� !
UserCreateException
�� /
(
��/ 0
s
��0 1
.
��1 2
Description
��2 =
)
��= >
)
��> ?
)
��? @
;
��@ A
}
�� 
var
�� 

roleResult
�� 
=
��  
await
��! &
_userManager
��' 3
.
��3 4
AddToRoleAsync
��4 B
(
��B C
user
��C G
,
��G H
$str
��I O
)
��O P
;
��P Q
if
�� 
(
�� 
!
�� 
createResult
�� !
.
��! "
	Succeeded
��" +
)
��+ ,
throw
�� 
new
��  
AggregateException
�� 0
(
��0 1

roleResult
�� "
.
��" #
Errors
��# )
.
��) *
Select
��* 0
(
��0 1
s
��1 2
=>
��3 5
new
��6 9!
UserCreateException
��: M
(
��M N
s
��N O
.
��O P
Description
��P [
)
��[ \
)
��\ ]
)
��] ^
;
��^ _
var
�� $
emailConfirmationToken
�� *
=
��+ ,
await
��- 2
_userManager
��3 ?
.
��? @1
#GenerateEmailConfirmationTokenAsync
��@ c
(
��c d
user
��d h
)
��h i
;
��i j
var
�� "
emailConfirmationUrl
�� (
=
��) *
Url
��+ .
.
��. /
Combine
��/ 6
(
��6 7
registration
��  
.
��  !
ConfirmEmailUrl
��! 0
.
��0 1
BaseAddress
��1 <
,
��< =
registration
��  
.
��  !
ConfirmEmailUrl
��! 0
.
��0 1
ControllerRoute
��1 @
,
��@ A
registration
��  
.
��  !
ConfirmEmailUrl
��! 0
.
��0 1
MethodRoute
��1 <
,
��< =
$"
�� 
$str
�� 
{
�� 
user
�� "
.
��" #
Email
��# (
}
��( )
$str
��) 0
{
��0 1$
emailConfirmationToken
��1 G
}
��G H
"
��H I
)
�� 
;
�� 
var
�� 
email
�� 
=
�� 
new
�� 
EmailRequest
��  ,
{
�� 
Subject
�� 
=
�� 
$str
�� '
,
��' (
Html
�� 
=
�� 
$"
�� 
$str
�� 2
{
��2 3"
emailConfirmationUrl
��3 G
}
��G H
"
��H I
,
��I J
EmailTo
�� 
=
�� 
user
�� "
.
��" #
Email
��# (
}
�� 
;
�� 
await
�� 
_emailService
�� #
.
��# $
	SendAsync
��$ -
(
��- .
email
��. 3
)
��3 4
;
��4 5
}
�� 
}
�� 	
public
�� 
async
�� 
Task
��  
GoogleRegistration
�� ,
(
��, -
string
��- 3
googleToken
��4 ?
)
��? @
{
�� 	
var
�� 
token
�� 
=
�� 
await
�� 
_jwtTokenManager
�� .
.
��. /
GoogleLogin
��/ :
(
��: ;
googleToken
��; F
)
��F G
;
��G H
var
�� 
email
�� 
=
�� 
await
�� 
_jwtTokenManager
�� .
.
��. /$
DecodeTokenAndGetEmail
��/ E
(
��E F
token
��F K
)
��K L
;
��L M
var
�� 
existingUser
�� 
=
�� 
await
�� $
_userManager
��% 1
.
��1 2
FindByEmailAsync
��2 B
(
��B C
email
��C H
)
��H I
;
��I J
if
�� 
(
�� 
existingUser
�� 
!=
�� 
null
��  $
)
��$ %
{
�� 
throw
�� 
new
�� !
UserCreateException
�� -
(
��- .
$str
��. S
)
��S T
;
��T U
}
�� 
var
�� 
user
�� 
=
�� 
new
�� 
Domain
�� !
.
��! "
Account
��" )
.
��) *
Entities
��* 2
.
��2 3
User
��3 7
{
�� 
Email
�� 
=
�� 
email
�� 
,
�� 
UserName
�� 
=
�� 
email
��  
,
��  !%
CustomizationSettingsId
�� '
=
��( )
await
��* /$
_customizationSettings
��0 F
.
��F G)
CreateCustomizationSettings
��G b
(
��b c
)
��c d
,
��d e
WhoBan
�� 
=
�� 
$str
�� 
}
�� 
;
�� 
var
�� 
createResult
�� 
=
�� 
await
�� $
_userManager
��% 1
.
��1 2
CreateAsync
��2 =
(
��= >
user
��> B
)
��B C
;
��C D
if
�� 
(
�� 
!
�� 
createResult
�� 
.
�� 
	Succeeded
�� '
)
��' (
{
�� 
throw
�� 
new
��  
AggregateException
�� ,
(
��, -
createResult
��- 9
.
��9 :
Errors
��: @
.
��@ A
Select
��A G
(
��G H
s
��H I
=>
��J L
new
�� !
UserCreateException
�� +
(
��+ ,
s
��, -
.
��- .
Description
��. 9
)
��9 :
)
��: ;
)
��; <
;
��< =
}
�� 
var
�� 

roleResult
�� 
=
�� 
await
�� "
_userManager
��# /
.
��/ 0
AddToRoleAsync
��0 >
(
��> ?
user
��? C
,
��C D
$str
��E K
)
��K L
;
��L M
if
�� 
(
�� 
!
�� 

roleResult
�� 
.
�� 
	Succeeded
�� %
)
��% &
{
�� 
throw
�� 
new
��  
AggregateException
�� ,
(
��, -

roleResult
�� 
.
�� 
Errors
�� %
.
��% &
Select
��& ,
(
��, -
s
��- .
=>
��/ 1
new
��2 5!
UserCreateException
��6 I
(
��I J
s
��J K
.
��K L
Description
��L W
)
��W X
)
��X Y
)
��Y Z
;
��Z [
}
�� 
}
�� 	
}
�� 
}�� �%
}C:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Infrastructure\Implementations\LoggingService.cs
	namespace 	
FanPage
 
. 
Infrastructure  
.  !
Implementations! 0
{ 
public		 

class		 
LoggingService		 
{

 
private 
readonly 
ILoggerFactory '
_loggerFactory( 6
;6 7
private 
readonly 
ILogger  
<  !
LoggingService! /
>/ 0
_logger1 8
;8 9
private 
readonly  
LoggingConfiguration -
_configuration. <
;< =
public 
LoggingService 
( 
ILoggerFactory ,
loggerFactory- :
,: ;
IOptions< D
<D E 
LoggingConfigurationE Y
>Y Z
configuration[ h
)h i
{ 	
_loggerFactory 
= 
loggerFactory *
;* +
_configuration 
= 
configuration *
.* +
Value+ 0
;0 1
_logger 
= 
loggerFactory #
.# $
CreateLogger$ 0
<0 1
LoggingService1 ?
>? @
(@ A
)A B
;B C
} 	
public 
void $
ConfigureDatabaseLogging ,
(, -#
DbContextOptionsBuilder- D
optionsBuilderE S
)S T
{ 	
if 
( 
_configuration 
. !
EnableDatabaseTracing 4
)4 5
{ 
optionsBuilder 
. 
UseLoggerFactory /
(/ 0
_loggerFactory0 >
)> ?
;? @
} 
} 	
public 
void 
LogApiRequest !
(! "
HttpContext" -
context. 5
)5 6
{   	
_logger!! 
.!! 
LogInformation!! "
(!!" #
_configuration!!# 1
.!!1 2
EnableApiLogging!!2 B
?"" 
$""" 
$str"" 
{"" 
context"" %
.""% &
Request""& -
.""- .
Method"". 4
}""4 5
$str""5 6
{""6 7
context""7 >
.""> ?
Request""? F
.""F G
Path""G K
}""K L
$str""L M
{""M N
DateTime""N V
.""V W
Now""W Z
}""Z [
$str""[ \
"""\ ]
:## 
$"## 
$str## 
{## 
nameof## $
(##$ %
LogApiRequest##% 2
)##2 3
}##3 4
$str##4 5
{##5 6
DateTime##6 >
.##> ?
Now##? B
}##B C
"##C D
)##D E
;##E F
}&& 	
public(( 
void(( 
LogApiResponse(( "
(((" #
HttpContext((# .
context((/ 6
)((6 7
{)) 	
_logger** 
.** 
LogInformation** "
(**" #
_configuration**# 1
.**1 2
EnableApiLogging**2 B
?++ 
$"++ 
$str++ 
{++ 
context++ &
.++& '
Response++' /
.++/ 0

StatusCode++0 :
}++: ;
$str++; <
{++< =
DateTime++= E
.++E F
Now++F I
}++I J
"++J K
:,, 
$",, 
$str,, 
{,, 
nameof,, $
(,,$ %
LogApiResponse,,% 3
),,3 4
},,4 5
$str,,5 6
{,,6 7
DateTime,,7 ?
.,,? @
Now,,@ C
},,C D
$str,,D E
{,,E F
context,,F M
.,,M N
Response,,N V
.,,V W

StatusCode,,W a
},,a b
$str,,b c
",,c d
),,d e
;,,e f
}// 	
public11 
void11 
LogInformation11 "
(11" #
string11# )
message11* 1
)111 2
{22 	
_logger33 
.33 
LogInformation33 "
(33" #
message33# *
,33* +
DateTime33, 4
.334 5
Now335 8
)338 9
;339 :
}44 	
public66 
void66 
LogError66 
(66 
string66 #
message66$ +
)66+ ,
{77 	
_logger88 
.88 
LogError88 
(88 
message88 $
,88$ %
DateTime88& .
.88. /
Now88/ 2
)882 3
;883 4
}99 	
}:: 
};; �Y
�C:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Infrastructure\Implementations\Fanfic\TagService.cs
	namespace

 	
FanPage


 
.

 
Infrastructure

  
.

  !
Implementations

! 0
.

0 1
Fanfic

1 7
;

7 8
public 
class 

TagService 
: 
ITag 
{ 
private 
readonly 
ITagRepository #
_tagRepository$ 2
;2 3
private 
readonly 
IFanficRepository &
_fanficRepository' 8
;8 9
private 
readonly 
IJwtTokenManager %
_jwtTokenManager& 6
;6 7
private 
readonly 
IAdmin 
_admin "
;" #
private 
readonly 
IMapper 
_mapper $
;$ %
public 


TagService 
( 
ITagRepository $
tagRepository% 2
,2 3
IFanficRepository4 E
fanficRepositoryF V
,V W
IJwtTokenManager 
jwtTokenManager (
,( )
IMapper* 1
mapper2 8
,8 9
IAdmin: @
adminA F
)F G
{ 
_tagRepository 
= 
tagRepository &
;& '
_fanficRepository 
= 
fanficRepository ,
;, -
_jwtTokenManager 
= 
jwtTokenManager *
;* +
_mapper 
= 
mapper 
; 
_admin 
= 
admin 
; 
}   
public"" 

async"" 
Task"" 
<"" 
TagDto"" 
>"" 
CreateTagAsync"" ,
("", -
int""- 0
fanficId""1 9
,""9 :
TagDto""; A
tagDto""B H
,""H I
HttpRequest""J U
request""V ]
)""] ^
{## 
var$$ 
fanfic$$ 
=$$ 
await$$ 
_fanficRepository$$ ,
.$$, -
GetByIdAsync$$- 9
($$9 :
fanficId$$: B
)$$B C
;$$C D
var%% 
userName%% 
=%% 
_jwtTokenManager%% '
.%%' ( 
GetUserNameFromToken%%( <
(%%< =
request%%= D
)%%D E
;%%E F
if&& 

(&& 
fanfic&& 
.&& 

AuthorName&& 
!=&&  
userName&&! )
&&&&* ,
fanfic&&- 3
==&&4 6
null&&7 ;
)&&; <
{'' 	
throw(( 
new(( 
FanficException(( %
(((% &
$str((& 4
)((4 5
;((5 6
})) 	
var++ 

tagAlready++ 
=++ 
await++ 
_tagRepository++ -
.++- .
GetByNameAsync++. <
(++< =
tagDto++= C
.++C D
Name++D H
)++H I
;++I J
if-- 

(-- 

tagAlready-- 
!=-- 
null-- 
)-- 
{.. 	
throw// 
new// 
FanficException// %
(//% &
$str//& 9
)//9 :
;//: ;
}00 	
var22 
result22 
=22 
await22 
_tagRepository22 )
.22) *
CreateAsync22* 5
(225 6
tagDto226 <
)22< =
;22= >
return44 
new44 
TagDto44 
(44 
)44 
{55 	
TagId66 
=66 
result66 
.66 
TagId66  
,66  !
Name77 
=77 
result77 
.77 
Name77 
}88 	
;88	 

}99 
public;; 

async;; 
Task;; 
<;; 
TagDto;; 
>;; 
SetTagAsync;; )
(;;) *
int;;* -
fanficId;;. 6
,;;6 7
string;;8 >
?;;> ?
name;;@ D
,;;D E
HttpRequest;;F Q
request;;R Y
);;Y Z
{<< 
var== 
fanfic== 
=== 
await== 
_fanficRepository== ,
.==, -
GetByIdAsync==- 9
(==9 :
fanficId==: B
)==B C
;==C D
var>> 
userName>> 
=>> 
_jwtTokenManager>> '
.>>' ( 
GetUserNameFromToken>>( <
(>>< =
request>>= D
)>>D E
;>>E F
var?? 
tag?? 
=?? 
await?? 
_tagRepository?? &
.??& '
GetByNameAsync??' 5
(??5 6
name??6 :
)??: ;
;??; <
var@@ 
tagAlreadyFanfic@@ 
=@@ 
await@@ $
_tagRepository@@% 3
.@@3 4!
GetTagByFanficIdAsync@@4 I
(@@I J
fanficId@@J R
,@@R S
tag@@T W
.@@W X
TagId@@X ]
)@@] ^
;@@^ _
ifBB 

(BB 
fanficBB 
.BB 

AuthorNameBB 
!=BB  
userNameBB! )
&&BB* ,
fanficBB- 3
==BB4 6
nullBB7 ;
)BB; <
{CC 	
throwDD 
newDD 
FanficExceptionDD %
(DD% &
$strDD& 4
)DD4 5
;DD5 6
}EE 	
ifGG 

(GG 
tagAlreadyFanficGG 
!=GG 
nullGG  $
)GG$ %
{HH 	
throwII 
newII 
FanficExceptionII %
(II% &
$strII& 9
)II9 :
;II: ;
}JJ 	
ifLL 

(LL 
tagLL 
==LL 
nullLL 
)LL 
{MM 	
throwNN 
newNN 
FanficExceptionNN %
(NN% &
$strNN& 5
)NN5 6
;NN6 7
}OO 	
varQQ 
tagIdQQ 
=QQ 
tagQQ 
.QQ 
TagIdQQ 
;QQ 
awaitRR 
_tagRepositoryRR 
.RR 
AddTagToFanficAsyncRR 0
(RR0 1
fanficIdRR1 9
,RR9 :
tagIdRR; @
)RR@ A
;RRA B
returnTT 
newTT 
TagDtoTT 
(TT 
)TT 
{UU 	
TagIdVV 
=VV 
tagVV 
.VV 
TagIdVV 
,VV 
NameWW 
=WW 
tagWW 
.WW 
NameWW 
}XX 	
;XX	 

}YY 
public\\ 

async\\ 
Task\\ 
<\\ 
TagDto\\ 
>\\  
DeleteTagFanficAsync\\ 2
(\\2 3
int\\3 6
fanficId\\7 ?
,\\? @
string\\A G
?\\G H
tagName\\I P
,\\P Q
HttpRequest\\R ]
request\\^ e
)\\e f
{]] 
var^^ 
fanfic^^ 
=^^ 
await^^ 
_fanficRepository^^ ,
.^^, -
GetByIdAsync^^- 9
(^^9 :
fanficId^^: B
)^^B C
;^^C D
var__ 
userName__ 
=__ 
_jwtTokenManager__ '
.__' ( 
GetUserNameFromToken__( <
(__< =
request__= D
)__D E
;__E F
var`` 
tag`` 
=`` 
await`` 
_tagRepository`` &
.``& '
GetByNameAsync``' 5
(``5 6
tagName``6 =
)``= >
;``> ?
ifbb 

(bb 
fanficbb 
.bb 

AuthorNamebb 
!=bb  
userNamebb! )
&&bb* ,
fanficbb- 3
==bb4 6
nullbb7 ;
)bb; <
{cc 	
throwdd 
newdd 
FanficExceptiondd %
(dd% &
$strdd& 4
)dd4 5
;dd5 6
}ee 	
awaitgg 
_tagRepositorygg 
.gg $
DeleteTagFromFanficAsyncgg 5
(gg5 6
fanficIdgg6 >
,gg> ?
tagNamegg@ G
)ggG H
;ggH I
returnii 
newii 
TagDtoii 
(ii 
)ii 
{jj 	
TagIdkk 
=kk 
tagkk 
.kk 
TagIdkk 
,kk 
Namell 
=ll 
tagNamell 
}mm 	
;mm	 

}nn 
publicpp 

asyncpp 
Taskpp 
DeleteTagAsyncpp $
(pp$ %
intpp% (
tagIdpp) .
,pp. /
HttpRequestpp0 ;
requestpp< C
)ppC D
{qq 
varrr 
tagrr 
=rr 
awaitrr 
_tagRepositoryrr &
.rr& '
GetByIdAsyncrr' 3
(rr3 4
tagIdrr4 9
)rr9 :
;rr: ;
varss 
adminss 
=ss 
awaitss 
_adminss  
.ss  !
GetAdminAsyncss! .
(ss. /
requestss/ 6
)ss6 7
;ss7 8
iftt 

(tt 
admintt 
.tt 
Rolett 
!=tt 
$strtt !
)tt! "
{uu 	
throwvv 
newvv 
FanficExceptionvv %
(vv% &
$strvv& D
)vvD E
;vvE F
}ww 	
ifyy 

(yy 
tagyy 
==yy 
nullyy 
)yy 
{zz 	
throw{{ 
new{{ 
FanficException{{ %
({{% &
$str{{& 4
){{4 5
;{{5 6
}|| 	
await~~ 
_tagRepository~~ 
.~~ 
DeleteAsync~~ (
(~~( )
tagId~~) .
)~~. /
;~~/ 0
} 
public
�� 

async
�� 
Task
�� 
<
�� 
List
�� 
<
�� 
TagDto
�� !
>
��! "
>
��" #
GetAllTagFanfic
��$ 3
(
��3 4
int
��4 7
fanficId
��8 @
)
��@ A
{
�� 
var
�� 
tags
�� 
=
�� 
await
�� 
_tagRepository
�� '
.
��' ($
GetTagsByFanficIdAsync
��( >
(
��> ?
fanficId
��? G
)
��G H
;
��H I
return
�� 
_mapper
�� 
.
�� 
Map
�� 
<
�� 
List
�� 
<
��  
TagDto
��  &
>
��& '
>
��' (
(
��( )
tags
��) -
)
��- .
;
��. /
}
�� 
public
�� 

async
�� 
Task
�� 
<
�� 
List
�� 
<
�� 
TagDto
�� !
>
��! "
>
��" #
GetAllTagAsync
��$ 2
(
��2 3
)
��3 4
{
�� 
var
�� 
tags
�� 
=
�� 
await
�� 
_tagRepository
�� '
.
��' (
GetAllAsync
��( 3
(
��3 4
)
��4 5
;
��5 6
return
�� 
_mapper
�� 
.
�� 
Map
�� 
<
�� 
List
�� 
<
��  
TagDto
��  &
>
��& '
>
��' (
(
��( )
tags
��) -
)
��- .
;
��. /
}
�� 
}�� �u
�C:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Infrastructure\Implementations\Fanfic\ReviewService.cs
	namespace		 	
FanPage		
 
.		 
Infrastructure		  
.		  !
Implementations		! 0
.		0 1
Fanfic		1 7
;		7 8
public 
class 
ReviewService 
: 
IReview $
{ 
private 
readonly 
IJwtTokenManager %
_jwtTokenManager& 6
;6 7
private 
readonly 
IFanficRepository &
_fanficRepository' 8
;8 9
public 

ReviewService 
( 
IJwtTokenManager )
jwtTokenManager* 9
,9 :
IFanficRepository; L
fanficRepositoryM ]
)] ^
{ 
_jwtTokenManager 
= 
jwtTokenManager *
;* +
_fanficRepository 
= 
fanficRepository ,
;, -
} 
public 

async 
Task 
< 

ReviewsDto  
>  !
CreateReviewAsync" 3
(3 4
int4 7
fanficId8 @
,@ A

ReviewsDtoB L

reviewsDtoM W
,W X
HttpRequestY d
requeste l
)l m
{ 
var 
fanfic 
= 
await 
_fanficRepository ,
., -
GetByIdAsync- 9
(9 :
fanficId: B
)B C
;C D
var 
userName 
= 
_jwtTokenManager '
.' ( 
GetUserNameFromToken( <
(< =
request= D
)D E
;E F

reviewsDto 
. 
UserName 
= 
userName &
;& '
if 

( 
fanfic 
== 
null 
) 
{ 	
throw 
new 
FanficException %
(% &
$"& (
$str( 4
"4 5
)5 6
;6 7
} 	
var!! 
reviewAlready!! 
=!! 
await!! !
_fanficRepository!!" 3
.!!3 4$
GetReviewByFanficIdAsync!!4 L
(!!L M
fanficId!!M U
,!!U V
userName!!W _
)!!_ `
;!!` a
if## 

(## 
reviewAlready## 
!=## 
null## !
)##! "
{$$ 	
throw%% 
new%% 
FanficException%% %
(%%% &
$"%%& (
$str%%( A
"%%A B
)%%B C
;%%C D
}&& 	
var(( 
result(( 
=(( 
await(( 
_fanficRepository(( ,
.((, -
CreateReviewAsync((- >
(((> ?
fanficId((? G
,((G H

reviewsDto((I S
)((S T
;((T U
return** 
new** 

ReviewsDto** 
(** 
)** 
{++ 	
FanficId,, 
=,, 
fanficId,, 
,,,  
ReviewId-- 
=-- 
result-- 
.-- 
ReviewId-- &
,--& '
Text.. 
=.. 
result.. 
... 
Text.. 
,.. 
CreationDate// 
=// 
result// !
.//! "
CreationDate//" .
,//. /
UserName00 
=00 
userName00 
,00  
Rating11 
=11 
result11 
.11 
Rating11 "
,11" #
}22 	
;22	 

}33 
public55 

async55 
Task55 
<55 

ReviewsDto55  
>55  !
UpdateReviewAsync55" 3
(553 4
int554 7
fanficId558 @
,55@ A

ReviewsDto55B L

reviewsDto55M W
,55W X
HttpRequest55Y d
request55e l
)55l m
{66 
var77 
fanfic77 
=77 
await77 
_fanficRepository77 ,
.77, -
GetByIdAsync77- 9
(779 :
fanficId77: B
)77B C
;77C D
var88 
userName88 
=88 
_jwtTokenManager88 '
.88' ( 
GetUserNameFromToken88( <
(88< =
request88= D
)88D E
;88E F
var99 
review99 
=99 
await99 
_fanficRepository99 ,
.99, -$
GetReviewByFanficIdAsync99- E
(99E F
fanficId99F N
,99N O
userName99P X
)99X Y
;99Y Z

reviewsDto:: 
.:: 
UserName:: 
=:: 
userName:: &
;::& '
if<< 

(<< 
fanfic<< 
==<< 
null<< 
)<< 
{== 	
throw>> 
new>> 
FanficException>> %
(>>% &
$">>& (
$str>>( 4
">>4 5
)>>5 6
;>>6 7
}?? 	
ifAA 

(AA 

reviewsDtoAA 
.AA 
UserNameAA 
!=AA  "
userNameAA# +
)AA+ ,
{BB 	
throwCC 
newCC 
FanficExceptionCC %
(CC% &
$"CC& (
$strCC( D
"CCD E
)CCE F
;CCF G
}DD 	
reviewFF 
.FF 
TextFF 
=FF 

reviewsDtoFF  
.FF  !
TextFF! %
??FF& (
reviewFF) /
.FF/ 0
TextFF0 4
;FF4 5
reviewGG 
.GG 
RatingGG 
=GG 
(GG 

reviewsDtoGG #
.GG# $
RatingGG$ *
!=GG+ -
$numGG. /
)GG/ 0
?GG1 2

reviewsDtoGG3 =
.GG= >
RatingGG> D
:GGE F
reviewGGG M
.GGM N
RatingGGN T
;GGT U
varII 
resultII 
=II 
awaitII 
_fanficRepositoryII ,
.II, -
UpdateReviewAsyncII- >
(II> ?
fanficIdII? G
,IIG H
reviewIII O
)IIO P
;IIP Q
returnKK 
newKK 

ReviewsDtoKK 
(KK 
)KK 
{LL 	
FanficIdMM 
=MM 
fanficIdMM 
,MM  
ReviewIdNN 
=NN 
resultNN 
.NN 
ReviewIdNN &
,NN& '
TextOO 
=OO 
resultOO 
.OO 
TextOO 
,OO 
CreationDatePP 
=PP 
resultPP !
.PP! "
CreationDatePP" .
,PP. /
UserNameQQ 
=QQ 
userNameQQ 
,QQ  
RatingRR 
=RR 
resultRR 
.RR 
RatingRR "
,RR" #
}SS 	
;SS	 

}TT 
publicVV 

asyncVV 
TaskVV 
DeleteReviewAsyncVV '
(VV' (
intVV( +
fanficIdVV, 4
,VV4 5
HttpRequestVV6 A
requestVVB I
)VVI J
{WW 
varXX 
fanficXX 
=XX 
awaitXX 
_fanficRepositoryXX ,
.XX, -
GetByIdAsyncXX- 9
(XX9 :
fanficIdXX: B
)XXB C
;XXC D
varYY 
userNameYY 
=YY 
_jwtTokenManagerYY '
.YY' ( 
GetUserNameFromTokenYY( <
(YY< =
requestYY= D
)YYD E
;YYE F
varZZ 
reviewZZ 
=ZZ 
awaitZZ 
_fanficRepositoryZZ ,
.ZZ, -$
GetReviewByFanficIdAsyncZZ- E
(ZZE F
fanficIdZZF N
,ZZN O
userNameZZP X
)ZZX Y
;ZZY Z
if\\ 

(\\ 
fanfic\\ 
==\\ 
null\\ 
)\\ 
{]] 	
throw^^ 
new^^ 
FanficException^^ %
(^^% &
$"^^& (
$str^^( 4
"^^4 5
)^^5 6
;^^6 7
}__ 	
ifaa 

(aa 
reviewaa 
.aa 
UserNameaa 
!=aa 
userNameaa '
)aa' (
{bb 	
throwcc 
newcc 
FanficExceptioncc %
(cc% &
$"cc& (
$strcc( D
"ccD E
)ccE F
;ccF G
}dd 	
awaitff 
_fanficRepositoryff 
.ff  
DeleteReviewAsyncff  1
(ff1 2
fanficIdff2 :
,ff: ;
userNameff< D
)ffD E
;ffE F
}gg 
publicii 

asyncii 
Taskii 
<ii 

ReviewsDtoii  
>ii  !$
GetReviewByFanficIdAsyncii" :
(ii: ;
intii; >
fanficIdii? G
,iiG H
stringiiI O
userNameiiP X
)iiX Y
{jj 
varkk 
resultkk 
=kk 
awaitkk 
_fanficRepositorykk ,
.kk, -$
GetReviewByFanficIdAsynckk- E
(kkE F
fanficIdkkF N
,kkN O
userNamekkP X
)kkX Y
;kkY Z
returnmm 
newmm 

ReviewsDtomm 
(mm 
)mm 
{nn 	
FanficIdoo 
=oo 
fanficIdoo 
,oo  
ReviewIdpp 
=pp 
resultpp 
.pp 
ReviewIdpp &
,pp& '
Textqq 
=qq 
resultqq 
.qq 
Textqq 
,qq 
CreationDaterr 
=rr 
resultrr !
.rr! "
CreationDaterr" .
,rr. /
UserNamess 
=ss 
userNamess 
,ss  
Ratingtt 
=tt 
resulttt 
.tt 
Ratingtt "
,tt" #
}uu 	
;uu	 

}vv 
publicxx 

asyncxx 
Taskxx 
<xx 
Listxx 
<xx 

ReviewsDtoxx %
>xx% &
>xx& ''
GetAllReviewByFanficIdAsyncxx( C
(xxC D
intxxD G
fanficIdxxH P
)xxP Q
{yy 
varzz 
reviewszz 
=zz 
awaitzz 
_fanficRepositoryzz -
.zz- .'
GetAllReviewByFanficIdAsynczz. I
(zzI J
fanficIdzzJ R
)zzR S
;zzS T
var{{ 
result{{ 
={{ 
reviews{{ 
.{{ 
Select{{ #
({{# $
s{{$ %
=>{{& (
new{{) ,

ReviewsDto{{- 7
({{7 8
){{8 9
{|| 	
FanficId}} 
=}} 
fanficId}} 
,}}  
ReviewId~~ 
=~~ 
s~~ 
.~~ 
ReviewId~~ !
,~~! "
Text 
= 
s 
. 
Text 
, 
CreationDate
�� 
=
�� 
s
�� 
.
�� 
CreationDate
�� )
,
��) *
UserName
�� 
=
�� 
s
�� 
.
�� 
UserName
�� !
,
��! "
Rating
�� 
=
�� 
s
�� 
.
�� 
Rating
�� 
,
�� 
}
�� 	
)
��	 

.
��
 
ToList
�� 
(
�� 
)
�� 
;
�� 
return
�� 
result
�� 
;
�� 
}
�� 
public
�� 

async
�� 
Task
�� 
<
�� 
List
�� 
<
�� 

ReviewsDto
�� %
>
��% &
>
��& ')
GetAllReviewByUserNameAsync
��( C
(
��C D
string
��D J
userName
��K S
)
��S T
{
�� 
var
�� 
reviews
�� 
=
�� 
await
�� 
_fanficRepository
�� -
.
��- .)
GetAllReviewByUserNameAsync
��. I
(
��I J
userName
��J R
)
��R S
;
��S T
var
�� 
result
�� 
=
�� 
reviews
�� 
.
�� 
Select
�� #
(
��# $
s
��$ %
=>
��& (
new
��) ,

ReviewsDto
��- 7
(
��7 8
)
��8 9
{
�� 	
FanficId
�� 
=
�� 
s
�� 
.
�� 
FanficId
�� !
,
��! "
ReviewId
�� 
=
�� 
s
�� 
.
�� 
ReviewId
�� !
,
��! "
Text
�� 
=
�� 
s
�� 
.
�� 
Text
�� 
,
�� 
CreationDate
�� 
=
�� 
s
�� 
.
�� 
CreationDate
�� )
,
��) *
UserName
�� 
=
�� 
userName
�� 
,
��  
Rating
�� 
=
�� 
s
�� 
.
�� 
Rating
�� 
,
�� 
}
�� 	
)
��	 

.
��
 
ToList
�� 
(
�� 
)
�� 
;
�� 
return
�� 
result
�� 
;
�� 
}
�� 
public
�� 

async
�� 
Task
�� 
<
�� 
List
�� 
<
�� 

ReviewsDto
�� %
>
��% &
>
��& '
GetAllReview
��( 4
(
��4 5
)
��5 6
{
�� 
var
�� 
reviews
�� 
=
�� 
await
�� 
_fanficRepository
�� -
.
��- .
GetAllReview
��. :
(
��: ;
)
��; <
;
��< =
var
�� 
result
�� 
=
�� 
reviews
�� 
.
�� 
Select
�� #
(
��# $
s
��$ %
=>
��& (
new
��) ,

ReviewsDto
��- 7
(
��7 8
)
��8 9
{
�� 	
FanficId
�� 
=
�� 
s
�� 
.
�� 
FanficId
�� !
,
��! "
ReviewId
�� 
=
�� 
s
�� 
.
�� 
ReviewId
�� !
,
��! "
Text
�� 
=
�� 
s
�� 
.
�� 
Text
�� 
,
�� 
CreationDate
�� 
=
�� 
s
�� 
.
�� 
CreationDate
�� )
,
��) *
UserName
�� 
=
�� 
s
�� 
.
�� 
UserName
�� !
,
��! "
Rating
�� 
=
�� 
s
�� 
.
�� 
Rating
�� 
,
�� 
}
�� 	
)
��	 

.
��
 
ToList
�� 
(
�� 
)
�� 
;
�� 
return
�� 
result
�� 
;
�� 
}
�� 
}�� ��
�C:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Infrastructure\Implementations\Fanfic\FanficService.cs
	namespace		 	
FanPage		
 
.		 
Infrastructure		  
.		  !
Implementations		! 0
.		0 1
Fanfic		1 7
{

 
public 

class 
FanficService 
:  
IFanfic! (
{ 
private 
readonly 
IJwtTokenManager )
_jwtTokenManager* :
;: ;
private 
readonly 
IFanficRepository *
_fanficRepository+ <
;< =
private 
readonly "
IFanficPhotoRepository /"
_fanficPhotoRepository0 F
;F G
private 
readonly 
ICategoryRepository ,
_categoryRepository- @
;@ A
private 
readonly 
ITagRepository '
_tagRepository( 6
;6 7
public 
FanficService 
( 
IJwtTokenManager -
jwtTokenManager. =
,= >
IFanficRepository? P
fanficRepositoryQ a
,a b"
IFanficPhotoRepository "!
fanficPhotoRepository# 8
,8 9
ICategoryRepository: M
categoryRepositoryN `
,` a
ITagRepository 
tagRepository (
)( )
{ 	
_jwtTokenManager 
= 
jwtTokenManager .
;. /
_fanficRepository 
= 
fanficRepository  0
;0 1"
_fanficPhotoRepository "
=# $!
fanficPhotoRepository% :
;: ;
_categoryRepository 
=  !
categoryRepository" 4
;4 5
_tagRepository 
= 
tagRepository *
;* +
} 	
public 
async 
Task 
< 
	FanficDto #
># $
CreateAsync% 0
(0 1
	CreateDto1 :
createFanfic; G
,G H
HttpRequestI T
requestU \
)\ ]
{ 	
var   
userName   
=   
_jwtTokenManager   +
.  + , 
GetUserNameFromToken  , @
(  @ A
request  A H
)  H I
;  I J
createFanfic!! 
.!! 

AuthorName!! #
=!!$ %
userName!!& .
;!!. /
var## 
fanficAlready## 
=## 
await##  %
_fanficRepository##& 7
.##7 8
LocalGetAllAsync##8 H
(##H I
)##I J
;##J K
if$$ 
($$ 
fanficAlready$$ 
.$$ 
Any$$ !
($$! "
f$$" #
=>$$$ &
f$$' (
.$$( )
Title$$) .
==$$/ 1
createFanfic$$2 >
.$$> ?
Title$$? D
)$$D E
)$$E F
{%% 
throw&& 
new&& 
FanficException&& )
(&&) *
$str&&* A
)&&A B
;&&B C
}'' 
var)) 
fanficResult)) 
=)) 
await)) $
_fanficRepository))% 6
.))6 7
CreateAsync))7 B
())B C
createFanfic))C O
)))O P
;))P Q
var++ 
fanficPhotoDto++ 
=++  
new++! $
FanficPhotoDto++% 3
{++4 5
FanficId++6 >
=++? @
fanficResult++A M
.++M N
Id++N P
,++P Q
Image++R W
=++X Y
createFanfic++Z f
.++f g
Image++g l
}++m n
;++n o
await,, "
_fanficPhotoRepository,, (
.,,( )
CreateAsync,,) 4
(,,4 5
fanficPhotoDto,,5 C
),,C D
;,,D E
foreach.. 
(.. 
var.. 
categoryName.. %
in..& (
createFanfic..) 5
...5 6

Categories..6 @
...@ A
OrEmptyIfNull..A N
(..N O
)..O P
)..P Q
{// 
var00 
categoryDto00 
=00  !
await00" '
_categoryRepository00( ;
.00; <
GetByNameAsync00< J
(00J K
categoryName00K W
)00W X
;00X Y
await11 
_categoryRepository11 )
.11) *$
AddCategoryToFanficAsync11* B
(11B C
fanficResult11C O
.11O P
Id11P R
,11R S
categoryDto11T _
.11_ `

CategoryId11` j
)11j k
;11k l
}22 
foreach44 
(44 
var44 
tagName44  
in44! #
createFanfic44$ 0
.440 1
Tags441 5
.445 6
OrEmptyIfNull446 C
(44C D
)44D E
.55 
Where55 
(55  
tagName55  '
=>55( *
!55+ ,
string55, 2
.552 3
IsNullOrEmpty553 @
(55@ A
tagName55A H
)55H I
)55I J
)55J K
{66 
var77 
existingTag77 
=77  !
await77" '
_tagRepository77( 6
.776 7
GetByNameAsync777 E
(77E F
tagName77F M
)77M N
;77N O
if88 
(88 
existingTag88 
==88  "
null88# '
)88' (
{99 
var:: 
tagDtos:: 
=::  !
new::" %
TagDto::& ,
{::- .
Name::/ 3
=::4 5
tagName::6 =
}::> ?
;::? @
await;; 
_tagRepository;; (
.;;( )
CreateAsync;;) 4
(;;4 5
tagDtos;;5 <
);;< =
;;;= >
}<< 
var>> 
tagDto>> 
=>> 
await>> "
_tagRepository>># 1
.>>1 2
GetByNameAsync>>2 @
(>>@ A
tagName>>A H
)>>H I
;>>I J
if?? 
(?? 
tagDto?? 
!=?? 
null?? "
&&??# %
fanficResult??& 2
!=??3 5
null??6 :
)??: ;
{@@ 
awaitAA 
_tagRepositoryAA (
.AA( )
AddTagToFanficAsyncAA) <
(AA< =
fanficResultAA= I
.AAI J
IdAAJ L
,AAL M
tagDtoAAN T
.AAT U
TagIdAAU Z
)AAZ [
;AA[ \
}BB 
}CC 
varEE 
categoryFanficEE 
=EE  
awaitEE! &
_categoryRepositoryEE' :
.EE: ;)
GetAllCategoryByFanficIdAsyncEE; X
(EEX Y
fanficResultEEY e
.EEe f
IdEEf h
)EEh i
;EEi j
varFF 
	tagFanficFF 
=FF 
awaitFF !
_tagRepositoryFF" 0
.FF0 1"
GetTagsByFanficIdAsyncFF1 G
(FFG H
fanficResultFFH T
.FFT U
IdFFU W
)FFW X
;FFX Y
varII 
resultII 
=II 
newII 
	FanficDtoII &
{JJ 
IdKK 
=KK 
fanficResultKK !
.KK! "
IdKK" $
,KK$ %
TitleLL 
=LL 
createFanficLL $
.LL$ %
TitleLL% *
,LL* +

AuthorNameMM 
=MM 
createFanficMM )
.MM) *

AuthorNameMM* 4
,MM4 5
ImageNN 
=NN 
createFanficNN $
.NN$ %
ImageNN% *
??NN+ -
ArrayNN. 3
.NN3 4
EmptyNN4 9
<NN9 :
byteNN: >
>NN> ?
(NN? @
)NN@ A
,NNA B
StageOO 
=OO 
createFanficOO $
.OO$ %
StageOO% *
,OO* +
LanguagePP 
=PP 
createFanficPP '
.PP' (
LanguagePP( 0
,PP0 1
DescriptionQQ 
=QQ 
createFanficQQ *
.QQ* +
DescriptionQQ+ 6
,QQ6 7
OriginFandomRR 
=RR 
createFanficRR +
.RR+ ,
OriginFandomRR, 8
,RR8 9
CreationDateSS 
=SS 
fanficResultSS +
.SS+ ,
CreationDateSS, 8
,SS8 9

CategoriesTT 
=TT 
categoryFanficTT +
?TT+ ,
.TT, -
SelectTT- 3
(TT3 4
cTT4 5
=>TT6 8
newTT9 <
CategoryDtoTT= H
{UU 
NameVV 
=VV 
cVV 
.VV 
NameVV !
,VV! "

CategoryIdWW 
=WW  
cWW! "
.WW" #

CategoryIdWW# -
}XX 
)XX 
.XX 
ToListXX 
(XX 
)XX 
,XX 
TagsYY 
=YY 
	tagFanficYY  
?YY  !
.YY! "
SelectYY" (
(YY( )
tYY) *
=>YY+ -
newYY. 1
TagDtoYY2 8
{ZZ 
Name[[ 
=[[ 
t[[ 
.[[ 
Name[[ !
,[[! "
TagId\\ 
=\\ 
t\\ 
.\\ 
TagId\\ #
,\\# $

IsApproved]] 
=]]  
t]]! "
.]]" #

IsApproved]]# -
}^^ 
)^^ 
.^^ 
ToList^^ 
(^^ 
)^^ 
,^^ 
}__ 
;__ 
return`` 
result`` 
;`` 
}aa 	
publicdd 
asyncdd 
Taskdd 
<dd 
	FanficDtodd #
>dd# $
UpdateAsyncdd% 0
(dd0 1
intdd1 4
fanficIddd5 =
,dd= >
	UpdateDtodd? H
updateFanficddI U
,ddU V
HttpRequestddW b
requestddc j
)ddj k
{ee 	
varff 
fanficff 
=ff 
awaitff 
_fanficRepositoryff 0
.ff0 1
GetByIdAsyncff1 =
(ff= >
fanficIdff> F
)ffF G
;ffG H
vargg 
userNamegg 
=gg 
_jwtTokenManagergg +
.gg+ , 
GetUserNameFromTokengg, @
(gg@ A
requestggA H
)ggH I
;ggI J
varii 
resultPhotoii 
=ii 
awaitii #"
_fanficPhotoRepositoryii$ :
.ii: ;
GetByIdAsyncii; G
(iiG H
fanficIdiiH P
)iiP Q
;iiQ R
ifkk 
(kk 
fanfickk 
.kk 

AuthorNamekk !
!=kk" $
userNamekk% -
&&kk. 0
fanfickk1 7
==kk8 :
nullkk; ?
)kk? @
{ll 
throwmm 
newmm 
FanficExceptionmm )
(mm) *
$strmm* 8
)mm8 9
;mm9 :
}nn 
fanficpp 
.pp 
Descriptionpp 
=pp  
updateFanficpp! -
.pp- .
Descriptionpp. 9
??pp: <
fanficpp= C
.ppC D
DescriptionppD O
;ppO P
fanficqq 
.qq 
OriginFandomqq 
=qq  !
updateFanficqq" .
.qq. /
OriginFandomqq/ ;
??qq< >
fanficqq? E
.qqE F
OriginFandomqqF R
;qqR S
fanficrr 
.rr 
Stagerr 
=rr 
updateFanficrr '
.rr' (
Stagerr( -
??rr. 0
fanficrr1 7
.rr7 8
Stagerr8 =
;rr= >
fanficss 
.ss 
Titless 
=ss 
updateFanficss '
.ss' (
Titless( -
??ss. 0
fanficss1 7
.ss7 8
Titless8 =
;ss= >
resultPhotott 
.tt 
Imagett 
=tt 
updateFanfictt  ,
.tt, -
Photott- 2
.tt2 3
Selecttt3 9
(tt9 :
stt: ;
=>tt< >
stt? @
.tt@ A
ImagettA F
)ttF G
.ttG H
FirstOrDefaultttH V
(ttV W
)ttW X
??ttY [
resultPhotott\ g
.ttg h
Imagetth m
;ttm n
varvv 
resultvv 
=vv 
newvv 
	UpdateDtovv &
(vv& '
)vv' (
{ww 
Descriptionxx 
=xx 
fanficxx $
.xx$ %
Descriptionxx% 0
,xx0 1
OriginFandomyy 
=yy 
fanficyy %
.yy% &
OriginFandomyy& 2
,yy2 3
Stagezz 
=zz 
fanficzz 
.zz 
Stagezz $
,zz$ %
Photo{{ 
={{ 
new{{ 
List{{  
<{{  !
FanficPhotoDto{{! /
>{{/ 0
({{0 1
){{1 2
{|| 
new}} 
(}} 
)}} 
{~~ 
Image 
= 
resultPhoto  +
.+ ,
Image, 1
}
�� 
}
�� 
}
�� 
;
�� 
await
�� 
_fanficRepository
�� #
.
��# $
UpdateAsync
��$ /
(
��/ 0
result
��0 6
,
��6 7
fanficId
��8 @
)
��@ A
;
��A B
return
�� 
new
�� 
	FanficDto
��  
(
��  !
)
��! "
{
�� 
Id
�� 
=
�� 
fanfic
�� 
.
�� 
Id
�� 
,
�� 

AuthorName
�� 
=
�� 
fanfic
�� #
.
��# $

AuthorName
��$ .
,
��. /
Title
�� 
=
�� 
fanfic
�� 
.
�� 
Title
�� $
,
��$ %
Description
�� 
=
�� 
fanfic
�� $
.
��$ %
Description
��% 0
,
��0 1
OriginFandom
�� 
=
�� 
fanfic
�� %
.
��% &
OriginFandom
��& 2
,
��2 3
Stage
�� 
=
�� 
fanfic
�� 
.
�� 
Stage
�� $
,
��$ %
Language
�� 
=
�� 
fanfic
�� !
.
��! "
Language
��" *
,
��* +
CreationDate
�� 
=
�� 
fanfic
�� %
.
��% &
CreationDate
��& 2
,
��2 3
Image
�� 
=
�� 
fanfic
�� 
.
�� 
Image
�� $
,
��$ %

Categories
�� 
=
�� 
fanfic
�� #
.
��# $

Categories
��$ .
?
��. /
.
��/ 0
Select
��0 6
(
��6 7
c
��7 8
=>
��9 ;
new
��< ?
CategoryDto
��@ K
{
�� 
Name
�� 
=
�� 
c
�� 
.
�� 
Name
�� !
,
��! "

CategoryId
�� 
=
��  
c
��! "
.
��" #

CategoryId
��# -
}
�� 
)
�� 
.
�� 
ToList
�� 
(
�� 
)
�� 
,
�� 
Tags
�� 
=
�� 
fanfic
�� 
.
�� 
Tags
�� "
?
��" #
.
��# $
Select
��$ *
(
��* +
t
��+ ,
=>
��- /
new
��0 3
TagDto
��4 :
{
�� 
Name
�� 
=
�� 
t
�� 
.
�� 
Name
�� !
,
��! "
TagId
�� 
=
�� 
t
�� 
.
�� 
TagId
�� #
,
��# $

IsApproved
�� 
=
��  
t
��! "
.
��" #

IsApproved
��# -
}
�� 
)
�� 
.
�� 
ToList
�� 
(
�� 
)
�� 
,
�� 
Chapters
�� 
=
�� 
fanfic
�� !
.
��! "
Chapters
��" *
?
��* +
.
��+ ,
Select
��, 2
(
��2 3
ch
��3 5
=>
��6 8
new
��9 <

ChapterDto
��= G
{
�� 
FanficId
�� 
=
�� 
fanfic
�� %
.
��% &
Id
��& (
,
��( )
Title
�� 
=
�� 
ch
�� 
.
�� 
Title
�� $
,
��$ %
Content
�� 
=
�� 
ch
��  
.
��  !
Content
��! (
}
�� 
)
�� 
.
�� 
ToList
�� 
(
�� 
)
�� 
,
�� 
Reviews
�� 
=
�� 
fanfic
��  
.
��  !
Reviews
��! (
?
��( )
.
��) *
Select
��* 0
(
��0 1
r
��1 2
=>
��3 5
new
��6 9

ReviewsDto
��: D
{
�� 
FanficId
�� 
=
�� 
fanfic
�� %
.
��% &
Id
��& (
,
��( )
ReviewId
�� 
=
�� 
r
��  
.
��  !
ReviewId
��! )
,
��) *
Text
�� 
=
�� 
r
�� 
.
�� 
Text
�� !
,
��! "
CreationDate
��  
=
��! "
r
��# $
.
��$ %
CreationDate
��% 1
,
��1 2
UserName
�� 
=
�� 
r
��  
.
��  !
UserName
��! )
,
��) *
Rating
�� 
=
�� 
r
�� 
.
�� 
Rating
�� %
}
�� 
)
�� 
.
�� 
Where
�� 
(
�� 
r
�� 
=>
�� 
r
�� 
.
��  
FanficId
��  (
==
��) +
fanfic
��, 2
.
��2 3
Id
��3 5
)
��5 6
.
��6 7
ToList
��7 =
(
��= >
)
��> ?
}
�� 
;
�� 
}
�� 	
public
�� 
async
�� 
Task
�� 
DeleteAsync
�� %
(
��% &
int
��& )
id
��* ,
,
��, -
HttpRequest
��. 9
request
��: A
)
��A B
{
�� 	
var
�� 
fanfic
�� 
=
�� 
await
�� 
_fanficRepository
�� 0
.
��0 1
GetByIdAsync
��1 =
(
��= >
id
��> @
)
��@ A
;
��A B
var
�� 
userName
�� 
=
�� 
_jwtTokenManager
�� +
.
��+ ,"
GetUserNameFromToken
��, @
(
��@ A
request
��A H
)
��H I
;
��I J
if
�� 
(
�� 
fanfic
�� 
.
�� 

AuthorName
�� !
!=
��" $
userName
��% -
&&
��. 0
fanfic
��1 7
==
��8 :
null
��; ?
)
��? @
{
�� 
throw
�� 
new
�� 
FanficException
�� )
(
��) *
$str
��* 8
)
��8 9
;
��9 :
}
�� 
await
�� 
_fanficRepository
�� #
.
��# $
DeleteAsync
��$ /
(
��/ 0
id
��0 2
)
��2 3
;
��3 4
}
�� 	
}
�� 
}�� ��
�C:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Infrastructure\Implementations\Fanfic\FanficDetailService.cs
	namespace 	
FanPage
 
. 
Infrastructure  
.  !
Implementations! 0
.0 1
Fanfic1 7
;7 8
public 
class 
FanficDetailService  
:! "
IFanficDetail# 0
{		 
private

 
readonly

 
IFanficRepository

 &
_fanficRepository

' 8
;

8 9
public 

FanficDetailService 
( 
IFanficRepository 0
fanficRepository1 A
)A B
{ 
_fanficRepository 
= 
fanficRepository ,
;, -
} 
public 

async 
Task 
< 
List 
< 
	FanficDto $
>$ %
>% &
GetAllAsync' 2
(2 3
int3 6
count7 <
)< =
{ 
var 
	allFanfic 
= 
await 
_fanficRepository /
./ 0
GetAllAsync0 ;
(; <
count< A
)A B
;B C
return 
	allFanfic 
. 
Select 
(  
fanfic  &
=>' )
new* -
	FanficDto. 7
{ 
Id 
= 
fanfic 
. 
Id 
, 

AuthorName 
= 
fanfic #
.# $

AuthorName$ .
,. /
Title 
= 
fanfic 
. 
Title $
,$ %
Description 
= 
fanfic $
.$ %
Description% 0
,0 1
OriginFandom 
= 
fanfic %
.% &
OriginFandom& 2
,2 3
Stage 
= 
fanfic 
. 
Stage $
,$ %
Language 
= 
fanfic !
.! "
Language" *
,* +
CreationDate 
= 
fanfic %
.% &
CreationDate& 2
,2 3
Image 
= 
fanfic 
. 
Image $
,$ %

Categories 
= 
fanfic #
.# $

Categories$ .
?   
.   
Select   
(   
c   
=>   !
new  " %
CategoryDto  & 1
{  2 3
Name  4 8
=  9 :
c  ; <
.  < =
Name  = A
,  A B

CategoryId  C M
=  N O
c  P Q
.  Q R

CategoryId  R \
}  ] ^
)  ^ _
.  _ `
ToList  ` f
(  f g
)  g h
,  h i
Tags!! 
=!! 
fanfic!! 
.!! 
Tags!! "
?"" 
."" 
Select"" 
("" 
t"" 
=>"" !
new""" %
TagDto""& ,
{""- .
Name""/ 3
=""4 5
t""6 7
.""7 8
Name""8 <
,""< =
TagId""> C
=""D E
t""F G
.""G H
TagId""H M
,""M N

IsApproved""O Y
=""Z [
t""\ ]
.""] ^

IsApproved""^ h
}""i j
)""j k
.""k l
ToList""l r
(""r s
)""s t
,""t u
Chapters## 
=## 
fanfic## !
.##! "
Chapters##" *
?##* +
.##+ ,
Select##, 2
(##2 3
ch##3 5
=>##6 8
new##9 <

ChapterDto##= G
{$$ 
FanficId$$ 
=$$  
fanfic$$! '
.$$' (
Id$$( *
,$$* +
Title$$, 1
=$$2 3
ch$$4 6
.$$6 7
Title$$7 <
,$$< =
Content$$> E
=$$F G
ch$$H J
.$$J K
Content$$K R
}$$S T
)$$T U
.$$U V
ToList$$V \
($$\ ]
)$$] ^
,$$^ _
Reviews%% 
=%% 
fanfic%%  
.%%  !
Reviews%%! (
?%%( )
.%%) *
Select%%* 0
(%%0 1
r%%1 2
=>%%3 5
new%%6 9

ReviewsDto%%: D
{&& 
FanficId''  
=''! "
fanfic''# )
.'') *
Id''* ,
,'', -
ReviewId((  
=((! "
r((# $
.(($ %
ReviewId((% -
,((- .
Text)) 
=)) 
r))  
.))  !
Text))! %
,))% &
CreationDate** $
=**% &
r**' (
.**( )
CreationDate**) 5
,**5 6
UserName++  
=++! "
r++# $
.++$ %
UserName++% -
,++- .
Rating,, 
=,,  
r,,! "
.,," #
Rating,,# )
}-- 
)-- 
... 
Where.. 
(.. 
r.. 
=>.. 
r..  !
...! "
FanficId.." *
==..+ -
fanfic... 4
...4 5
Id..5 7
)..7 8
.// 
ToList// 
(// 
)// 
}00 
)00 
.11 
ToList11 
(11 
)11 
;11 
}22 
public55 

async55 
Task55 
<55 
List55 
<55 
	FanficDto55 $
>55$ %
>55% & 
GetByAuthorNameAsync55' ;
(55; <
string55< B
name55C G
,55G H
int55I L
count55M R
)55R S
{66 
var77 
byAuthorNameAsync77 
=77 
await77  %
_fanficRepository77& 7
.777 8 
GetByAuthorNameAsync778 L
(77L M
name77M Q
,77Q R
count77S X
)77X Y
;77Y Z
return88 
byAuthorNameAsync88  
.88  !
Select88! '
(88' (
fanfic88( .
=>88/ 1
new882 5
	FanficDto886 ?
{99 
Id:: 
=:: 
fanfic:: 
.:: 
Id:: 
,:: 

AuthorName;; 
=;; 
fanfic;; #
.;;# $

AuthorName;;$ .
,;;. /
Title<< 
=<< 
fanfic<< 
.<< 
Title<< $
,<<$ %
Description== 
=== 
fanfic== $
.==$ %
Description==% 0
,==0 1
OriginFandom>> 
=>> 
fanfic>> %
.>>% &
OriginFandom>>& 2
,>>2 3
Stage?? 
=?? 
fanfic?? 
.?? 
Stage?? $
,??$ %
Language@@ 
=@@ 
fanfic@@ !
.@@! "
Language@@" *
,@@* +
CreationDateAA 
=AA 
fanficAA %
.AA% &
CreationDateAA& 2
,AA2 3
ImageBB 
=BB 
fanficBB 
.BB 
ImageBB $
,BB$ %

CategoriesCC 
=CC 
fanficCC #
.CC# $

CategoriesCC$ .
?DD 
.DD 
SelectDD 
(DD 
cDD 
=>DD !
newDD" %
CategoryDtoDD& 1
{DD2 3
NameDD4 8
=DD9 :
cDD; <
.DD< =
NameDD= A
,DDA B

CategoryIdDDC M
=DDN O
cDDP Q
.DDQ R

CategoryIdDDR \
}DD] ^
)DD^ _
.DD_ `
ToListDD` f
(DDf g
)DDg h
,DDh i
TagsEE 
=EE 
fanficEE 
.EE 
TagsEE "
?FF 
.FF 
SelectFF 
(FF 
tFF 
=>FF !
newFF" %
TagDtoFF& ,
{FF- .
NameFF/ 3
=FF4 5
tFF6 7
.FF7 8
NameFF8 <
,FF< =
TagIdFF> C
=FFD E
tFFF G
.FFG H
TagIdFFH M
,FFM N

IsApprovedFFO Y
=FFZ [
tFF\ ]
.FF] ^

IsApprovedFF^ h
}FFi j
)FFj k
.FFk l
ToListFFl r
(FFr s
)FFs t
,FFt u
ChaptersGG 
=GG 
fanficGG !
.GG! "
ChaptersGG" *
?GG* +
.GG+ ,
SelectGG, 2
(GG2 3
chGG3 5
=>GG6 8
newGG9 <

ChapterDtoGG= G
{HH 
FanficIdHH 
=HH  
fanficHH! '
.HH' (
IdHH( *
,HH* +
TitleHH, 1
=HH2 3
chHH4 6
.HH6 7
TitleHH7 <
,HH< =
ContentHH> E
=HHF G
chHHH J
.HHJ K
ContentHHK R
}HHS T
)HHT U
.HHU V
ToListHHV \
(HH\ ]
)HH] ^
,HH^ _
ReviewsII 
=II 
fanficII  
.II  !
ReviewsII! (
?II( )
.II) *
SelectII* 0
(II0 1
rII1 2
=>II3 5
newII6 9

ReviewsDtoII: D
{JJ 
FanficIdKK  
=KK! "
fanficKK# )
.KK) *
IdKK* ,
,KK, -
ReviewIdLL  
=LL! "
rLL# $
.LL$ %
ReviewIdLL% -
,LL- .
TextMM 
=MM 
rMM  
.MM  !
TextMM! %
,MM% &
CreationDateNN $
=NN% &
rNN' (
.NN( )
CreationDateNN) 5
,NN5 6
UserNameOO  
=OO! "
rOO# $
.OO$ %
UserNameOO% -
,OO- .
RatingPP 
=PP  
rPP! "
.PP" #
RatingPP# )
}QQ 
)QQ 
.RR 
WhereRR 
(RR 
rRR 
=>RR 
rRR  !
.RR! "
FanficIdRR" *
==RR+ -
fanficRR. 4
.RR4 5
IdRR5 7
)RR7 8
.SS 
ToListSS 
(SS 
)SS 
}TT 
)TT 
.UU 
ToListUU 
(UU 
)UU 
;UU 
}VV 
publicXX 

asyncXX 
TaskXX 
<XX 
ListXX 
<XX 
	FanficDtoXX $
>XX$ %
>XX% &+
GetLastCreationDateFanficsAsyncXX' F
(XXF G
intXXG J
countXXK P
,XXP Q
HttpRequestXXR ]
requestXX^ e
)XXe f
{YY 
varZZ (
lastCreationDateFanficsAsyncZZ (
=ZZ) *
awaitZZ+ 0
_fanficRepositoryZZ1 B
.ZZB C+
GetLastCreationDateFanficsAsyncZZC b
(ZZb c
countZZc h
)ZZh i
;ZZi j
return\\ (
lastCreationDateFanficsAsync\\ +
.\\+ ,
Select\\, 2
(\\2 3
fanfic\\3 9
=>\\: <
new\\= @
	FanficDto\\A J
{]] 
Id^^ 
=^^ 
fanfic^^ 
.^^ 
Id^^ 
,^^ 

AuthorName__ 
=__ 
fanfic__ #
.__# $

AuthorName__$ .
,__. /
Title`` 
=`` 
fanfic`` 
.`` 
Title`` $
,``$ %
Descriptionaa 
=aa 
fanficaa $
.aa$ %
Descriptionaa% 0
,aa0 1
OriginFandombb 
=bb 
fanficbb %
.bb% &
OriginFandombb& 2
,bb2 3
Stagecc 
=cc 
fanficcc 
.cc 
Stagecc $
,cc$ %
Languagedd 
=dd 
fanficdd !
.dd! "
Languagedd" *
,dd* +
CreationDateee 
=ee 
fanficee %
.ee% &
CreationDateee& 2
,ee2 3
Imageff 
=ff 
fanficff 
.ff 
Imageff $
,ff$ %

Categoriesgg 
=gg 
fanficgg #
.gg# $

Categoriesgg$ .
?hh 
.hh 
Selecthh 
(hh 
chh 
=>hh !
newhh" %
CategoryDtohh& 1
{hh2 3
Namehh4 8
=hh9 :
chh; <
.hh< =
Namehh= A
,hhA B

CategoryIdhhC M
=hhN O
chhP Q
.hhQ R

CategoryIdhhR \
}hh] ^
)hh^ _
.hh_ `
ToListhh` f
(hhf g
)hhg h
,hhh i
Tagsii 
=ii 
fanficii 
.ii 
Tagsii "
?jj 
.jj 
Selectjj 
(jj 
tjj 
=>jj !
newjj" %
TagDtojj& ,
{jj- .
Namejj/ 3
=jj4 5
tjj6 7
.jj7 8
Namejj8 <
,jj< =
TagIdjj> C
=jjD E
tjjF G
.jjG H
TagIdjjH M
,jjM N

IsApprovedjjO Y
=jjZ [
tjj\ ]
.jj] ^

IsApprovedjj^ h
}jji j
)jjj k
.jjk l
ToListjjl r
(jjr s
)jjs t
,jjt u
Chapterskk 
=kk 
fanfickk !
.kk! "
Chapterskk" *
?kk* +
.kk+ ,
Selectkk, 2
(kk2 3
chkk3 5
=>kk6 8
newkk9 <

ChapterDtokk= G
{ll 
FanficIdll 
=ll  
fanficll! '
.ll' (
Idll( *
,ll* +
Titlell, 1
=ll2 3
chll4 6
.ll6 7
Titlell7 <
,ll< =
Contentll> E
=llF G
chllH J
.llJ K
ContentllK R
}llS T
)llT U
.llU V
ToListllV \
(ll\ ]
)ll] ^
,ll^ _
Reviewsmm 
=mm 
fanficmm  
.mm  !
Reviewsmm! (
?mm( )
.mm) *
Selectmm* 0
(mm0 1
rmm1 2
=>mm3 5
newmm6 9

ReviewsDtomm: D
{nn 
FanficIdoo  
=oo! "
fanficoo# )
.oo) *
Idoo* ,
,oo, -
ReviewIdpp  
=pp! "
rpp# $
.pp$ %
ReviewIdpp% -
,pp- .
Textqq 
=qq 
rqq  
.qq  !
Textqq! %
,qq% &
CreationDaterr $
=rr% &
rrr' (
.rr( )
CreationDaterr) 5
,rr5 6
UserNamess  
=ss! "
rss# $
.ss$ %
UserNamess% -
,ss- .
Ratingtt 
=tt  
rtt! "
.tt" #
Ratingtt# )
}uu 
)uu 
.vv 
Wherevv 
(vv 
rvv 
=>vv 
rvv  !
.vv! "
FanficIdvv" *
==vv+ -
fanficvv. 4
.vv4 5
Idvv5 7
)vv7 8
.ww 
ToListww 
(ww 
)ww 
}xx 
)xx 
.yy 
ToListyy 
(yy 
)yy 
;yy 
}zz 
public}} 

async}} 
Task}} 
<}} 
List}} 
<}} 
	FanficDto}} $
>}}$ %
>}}% &$
GetTopRatingFanficsAsync}}' ?
(}}? @
int}}@ C
count}}D I
,}}I J
HttpRequest}}K V
request}}W ^
)}}^ _
{~~ 
var 
fanfic 
= 
await 
_fanficRepository ,
., -$
GetTopRatingFanficsAsync- E
(E F
countF K
)K L
;L M
return
�� 
fanfic
�� 
.
�� 
Select
�� 
(
�� 
dto
��  
=>
��! #
new
��$ '
	FanficDto
��( 1
{
�� 
Id
�� 
=
�� 
dto
�� 
.
�� 
Id
�� 
,
�� 

AuthorName
�� 
=
�� 
dto
��  
.
��  !

AuthorName
��! +
,
��+ ,
Title
�� 
=
�� 
dto
�� 
.
�� 
Title
�� !
,
��! "
Description
�� 
=
�� 
dto
�� !
.
��! "
Description
��" -
,
��- .
OriginFandom
�� 
=
�� 
dto
�� "
.
��" #
OriginFandom
��# /
,
��/ 0
Stage
�� 
=
�� 
dto
�� 
.
�� 
Stage
�� !
,
��! "
Language
�� 
=
�� 
dto
�� 
.
�� 
Language
�� '
,
��' (
CreationDate
�� 
=
�� 
dto
�� "
.
��" #
CreationDate
��# /
,
��/ 0
Image
�� 
=
�� 
dto
�� 
.
�� 
Image
�� !
,
��! "

Categories
�� 
=
�� 
dto
��  
.
��  !

Categories
��! +
?
�� 
.
�� 
Select
�� 
(
�� 
c
�� 
=>
�� !
new
��" %
CategoryDto
��& 1
{
��2 3
Name
��4 8
=
��9 :
c
��; <
.
��< =
Name
��= A
,
��A B

CategoryId
��C M
=
��N O
c
��P Q
.
��Q R

CategoryId
��R \
}
��] ^
)
��^ _
.
��_ `
ToList
��` f
(
��f g
)
��g h
,
��h i
Tags
�� 
=
�� 
dto
�� 
.
�� 
Tags
�� 
?
�� 
.
�� 
Select
�� 
(
�� 
t
�� 
=>
�� !
new
��" %
TagDto
��& ,
{
��- .
Name
��/ 3
=
��4 5
t
��6 7
.
��7 8
Name
��8 <
,
��< =
TagId
��> C
=
��D E
t
��F G
.
��G H
TagId
��H M
,
��M N

IsApproved
��O Y
=
��Z [
t
��\ ]
.
��] ^

IsApproved
��^ h
}
��i j
)
��j k
.
��k l
ToList
��l r
(
��r s
)
��s t
,
��t u
Chapters
�� 
=
�� 
dto
�� 
.
�� 
Chapters
�� '
?
��' (
.
��( )
Select
��) /
(
��/ 0
ch
��0 2
=>
��3 5
new
��6 9

ChapterDto
��: D
{
�� 
FanficId
�� 
=
��  
dto
��! $
.
��$ %
Id
��% '
,
��' (
Title
��) .
=
��/ 0
ch
��1 3
.
��3 4
Title
��4 9
,
��9 :
Content
��; B
=
��C D
ch
��E G
.
��G H
Content
��H O
}
��P Q
)
��Q R
.
��R S
ToList
��S Y
(
��Y Z
)
��Z [
,
��[ \
Reviews
�� 
=
�� 
dto
�� 
.
�� 
Reviews
�� %
?
��% &
.
��& '
Select
��' -
(
��- .
r
��. /
=>
��0 2
new
��3 6

ReviewsDto
��7 A
{
�� 
FanficId
��  
=
��! "
dto
��# &
.
��& '
Id
��' )
,
��) *
ReviewId
��  
=
��! "
r
��# $
.
��$ %
ReviewId
��% -
,
��- .
Text
�� 
=
�� 
r
��  
.
��  !
Text
��! %
,
��% &
CreationDate
�� $
=
��% &
r
��' (
.
��( )
CreationDate
��) 5
,
��5 6
UserName
��  
=
��! "
r
��# $
.
��$ %
UserName
��% -
,
��- .
Rating
�� 
=
��  
r
��! "
.
��" #
Rating
��# )
}
�� 
)
�� 
.
�� 
Where
�� 
(
�� 
r
�� 
=>
�� 
r
��  !
.
��! "
FanficId
��" *
==
��+ -
dto
��. 1
.
��1 2
Id
��2 4
)
��4 5
.
�� 
ToList
�� 
(
�� 
)
�� 
}
�� 
)
�� 
.
�� 
ToList
�� 
(
�� 
)
�� 
;
�� 
}
�� 
public
�� 

async
�� 
Task
�� 
<
�� 
	FanficDto
�� 
>
��  
GetByIdAsync
��! -
(
��- .
int
��. 1
id
��2 4
)
��4 5
{
�� 
var
�� 
fanfic
�� 
=
�� 
await
�� 
_fanficRepository
�� ,
.
��, -
GetByIdAsync
��- 9
(
��9 :
id
��: <
)
��< =
;
��= >
return
�� 
new
�� 
	FanficDto
�� 
{
�� 	
Id
�� 
=
�� 
fanfic
�� 
.
�� 
Id
�� 
,
�� 

AuthorName
�� 
=
�� 
fanfic
�� 
.
��  

AuthorName
��  *
,
��* +
Title
�� 
=
�� 
fanfic
�� 
.
�� 
Title
��  
,
��  !
Description
�� 
=
�� 
fanfic
��  
.
��  !
Description
��! ,
,
��, -
OriginFandom
�� 
=
�� 
fanfic
�� !
.
��! "
OriginFandom
��" .
,
��. /
Stage
�� 
=
�� 
fanfic
�� 
.
�� 
Stage
��  
,
��  !
Language
�� 
=
�� 
fanfic
�� 
.
�� 
Language
�� &
,
��& '
CreationDate
�� 
=
�� 
fanfic
�� !
.
��! "
CreationDate
��" .
,
��. /
Image
�� 
=
�� 
fanfic
�� 
.
�� 
Image
��  
,
��  !

Categories
�� 
=
�� 
fanfic
�� 
.
��  

Categories
��  *
?
��* +
.
��+ ,
Select
��, 2
(
��2 3
c
��3 4
=>
��5 7
new
��8 ;
CategoryDto
��< G
{
�� 
Name
�� 
=
�� 
c
�� 
.
�� 
Name
�� 
,
�� 

CategoryId
�� 
=
�� 
c
�� 
.
�� 

CategoryId
�� )
}
�� 
)
�� 
.
�� 
ToList
�� 
(
�� 
)
�� 
,
�� 
Tags
�� 
=
�� 
fanfic
�� 
.
�� 
Tags
�� 
?
�� 
.
��  
Select
��  &
(
��& '
t
��' (
=>
��) +
new
��, /
TagDto
��0 6
{
�� 
Name
�� 
=
�� 
t
�� 
.
�� 
Name
�� 
,
�� 
TagId
�� 
=
�� 
t
�� 
.
�� 
TagId
�� 
,
��  

IsApproved
�� 
=
�� 
t
�� 
.
�� 

IsApproved
�� )
}
�� 
)
�� 
.
�� 
ToList
�� 
(
�� 
)
�� 
,
�� 
Chapters
�� 
=
�� 
fanfic
�� 
.
�� 
Chapters
�� &
?
��& '
.
��' (
Select
��( .
(
��. /
ch
��/ 1
=>
��2 4
new
��5 8

ChapterDto
��9 C
{
�� 
FanficId
�� 
=
�� 
fanfic
�� !
.
��! "
Id
��" $
,
��$ %
Title
�� 
=
�� 
ch
�� 
.
�� 
Title
��  
,
��  !
Content
�� 
=
�� 
ch
�� 
.
�� 
Content
�� $
}
�� 
)
�� 
.
�� 
ToList
�� 
(
�� 
)
�� 
,
�� 
Reviews
�� 
=
�� 
fanfic
�� 
.
�� 
Reviews
�� $
?
��$ %
.
��% &
Select
��& ,
(
��, -
r
��- .
=>
��/ 1
new
��2 5

ReviewsDto
��6 @
{
�� 
FanficId
�� 
=
�� 
fanfic
�� !
.
��! "
Id
��" $
,
��$ %
ReviewId
�� 
=
�� 
r
�� 
.
�� 
ReviewId
�� %
,
��% &
Text
�� 
=
�� 
r
�� 
.
�� 
Text
�� 
,
�� 
CreationDate
�� 
=
�� 
r
��  
.
��  !
CreationDate
��! -
,
��- .
UserName
�� 
=
�� 
r
�� 
.
�� 
UserName
�� %
,
��% &
Rating
�� 
=
�� 
r
�� 
.
�� 
Rating
�� !
}
�� 
)
�� 
.
�� 
Where
�� 
(
�� 
r
�� 
=>
�� 
r
�� 
.
�� 
FanficId
�� $
==
��% '
fanfic
��( .
.
��. /
Id
��/ 1
)
��1 2
.
��2 3
ToList
��3 9
(
��9 :
)
��: ;
}
�� 	
;
��	 

}
�� 
public
�� 

Task
�� 
<
�� 
double
�� 
>
�� #
GetAverageRatingAsync
�� -
(
��- .
int
��. 1
fanficId
��2 :
)
��: ;
{
�� 
var
��  
averageRatingAsync
�� 
=
��  
_fanficRepository
��! 2
.
��2 3#
GetAverageRatingAsync
��3 H
(
��H I
fanficId
��I Q
)
��Q R
;
��R S
return
��  
averageRatingAsync
�� !
;
��! "
}
�� 
public
�� 

async
�� 
Task
�� 
<
�� 
List
�� 
<
�� 
	FanficDto
�� $
>
��$ %
>
��% &
SearchAsync
��' 2
(
��2 3
string
��3 9
searchString
��: F
,
��F G
bool
��H L
original
��M U
)
��U V
{
�� 
var
�� 

fanficList
�� 
=
�� 
await
�� 
_fanficRepository
�� 0
.
��0 1
SearchAsync
��1 <
(
��< =
searchString
��= I
,
��I J
original
��K S
)
��S T
;
��T U
return
�� 

fanficList
�� 
.
�� 
Select
��  
(
��  !
fanfic
��! '
=>
��( *
new
��+ .
	FanficDto
��/ 8
(
��8 9
)
��9 :
{
�� 	
Id
�� 
=
�� 
fanfic
�� 
.
�� 
Id
�� 
,
�� 

AuthorName
�� 
=
�� 
fanfic
�� 
.
��  

AuthorName
��  *
,
��* +
Title
�� 
=
�� 
fanfic
�� 
.
�� 
Title
��  
,
��  !
Description
�� 
=
�� 
fanfic
��  
.
��  !
Description
��! ,
,
��, -
OriginFandom
�� 
=
�� 
fanfic
�� !
.
��! "
OriginFandom
��" .
,
��. /
Stage
�� 
=
�� 
fanfic
�� 
.
�� 
Stage
��  
,
��  !
Language
�� 
=
�� 
fanfic
�� 
.
�� 
Language
�� &
,
��& '
CreationDate
�� 
=
�� 
fanfic
�� !
.
��! "
CreationDate
��" .
,
��. /
Image
�� 
=
�� 
fanfic
�� 
.
�� 
Image
��  
,
��  !

Categories
�� 
=
�� 
fanfic
�� 
.
��  

Categories
��  *
?
��* +
.
��+ ,
Select
��, 2
(
��2 3
s
��3 4
=>
��5 7
new
��8 ;
CategoryDto
��< G
(
��G H
)
��H I
{
�� 
Name
�� 
=
�� 
s
�� 
.
�� 
Name
�� 
,
�� 

CategoryId
�� 
=
�� 
s
�� 
.
�� 

CategoryId
�� )
}
�� 
)
�� 
.
�� 
ToList
�� 
(
�� 
)
�� 
,
�� 
Tags
�� 
=
�� 
fanfic
�� 
.
�� 
Tags
�� 
?
�� 
.
��  
Select
��  &
(
��& '
s
��' (
=>
��) +
new
��, /
TagDto
��0 6
(
��6 7
)
��7 8
{
�� 
Name
�� 
=
�� 
s
�� 
.
�� 
Name
�� 
,
�� 
TagId
�� 
=
�� 
s
�� 
.
�� 
TagId
�� 
,
��  

IsApproved
�� 
=
�� 
s
�� 
.
�� 

IsApproved
�� )
}
�� 
)
�� 
.
�� 
ToList
�� 
(
�� 
)
�� 
,
�� 
Chapters
�� 
=
�� 
fanfic
�� 
.
�� 
Chapters
�� &
?
��& '
.
��' (
Select
��( .
(
��. /
s
��/ 0
=>
��1 3
new
��4 7

ChapterDto
��8 B
(
��B C
)
��C D
{
�� 
FanficId
�� 
=
�� 
fanfic
�� !
.
��! "
Id
��" $
,
��$ %
Title
�� 
=
�� 
s
�� 
.
�� 
Title
�� 
,
��  
Content
�� 
=
�� 
s
�� 
.
�� 
Content
�� #
,
��# $
}
�� 
)
�� 
.
�� 
ToList
�� 
(
�� 
)
�� 
,
�� 
Reviews
�� 
=
�� 
fanfic
�� 
.
�� 
Reviews
�� $
?
��$ %
.
��% &
Select
��& ,
(
��, -
s
��- .
=>
��/ 1
new
��2 5

ReviewsDto
��6 @
(
��@ A
)
��A B
{
�� 
FanficId
�� 
=
�� 
fanfic
�� !
.
��! "
Id
��" $
,
��$ %
ReviewId
�� 
=
�� 
s
�� 
.
�� 
ReviewId
�� %
,
��% &
Text
�� 
=
�� 
s
�� 
.
�� 
Text
�� 
,
�� 
CreationDate
�� 
=
�� 
s
��  
.
��  !
CreationDate
��! -
,
��- .
UserName
�� 
=
�� 
s
�� 
.
�� 
UserName
�� %
,
��% &
Rating
�� 
=
�� 
s
�� 
.
�� 
Rating
�� !
,
��! "
}
�� 
)
�� 
.
�� 
Where
�� 
(
�� 
w
�� 
=>
�� 
w
�� 
.
�� 
FanficId
�� $
==
��% '
fanfic
��( .
.
��. /
Id
��/ 1
)
��1 2
.
��2 3
ToList
��3 9
(
��9 :
)
��: ;
}
�� 	
)
��	 

.
��
 
ToList
�� 
(
�� 
)
�� 
;
�� 
}
�� 
}�� �o
�C:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Infrastructure\Implementations\Fanfic\CommentService.cs
	namespace 	
FanPage
 
. 
Infrastructure  
.  !
Implementations! 0
.0 1
Fanfic1 7
;7 8
public

 
class

 
CommentService

 
:

 
IComment

 &
{ 
private 
readonly #
ICommentPhotoRepository ,#
_commentPhotoRepository- D
;D E
private 
readonly 
ICommentRepository '
_commentRepository( :
;: ;
private 
readonly 
IJwtTokenManager %
_jwtTokenManager& 6
;6 7
private 
readonly 
IFanficRepository &
_fanficRepository' 8
;8 9
public 

CommentService 
( 
ICommentRepository ,
commentRepository- >
,> ?
IJwtTokenManager@ P
jwtTokenManagerQ `
,` a
IFanficRepository 
fanficRepository *
,* +#
ICommentPhotoRepository, C"
commentPhotoRepositoryD Z
)Z [
{ 
_commentRepository 
= 
commentRepository .
;. /
_jwtTokenManager 
= 
jwtTokenManager *
;* +
_fanficRepository 
= 
fanficRepository ,
;, -#
_commentPhotoRepository 
=  !"
commentPhotoRepository" 8
;8 9
} 
public 

async 
Task 
< 

CommentDto  
>  !
AddCommentAsync" 1
(1 2

CommentDto2 <

commentDto= G
,G H
HttpRequestI T
requestU \
)\ ]
{ 
var 

authorName 
= 
_jwtTokenManager )
.) * 
GetUserNameFromToken* >
(> ?
request? F
)F G
;G H
var   
fanfic   
=   
_fanficRepository   &
.  & '
GetByIdAsync  ' 3
(  3 4

commentDto  4 >
.  > ?
FanficId  ? G
)  G H
;  H I

commentDto"" 
."" 

AuthorName"" 
="" 

authorName""  *
;""* +
var$$ 
commentPhotoDto$$ 
=$$ 
new$$ !
CommentPhotoDto$$" 1
{%% 	
	CommentId&& 
=&& 

commentDto&& "
.&&" #
	CommentId&&# ,
,&&, -
Image'' 
='' 

commentDto'' 
.'' 
Image'' $
}(( 	
;((	 

await** #
_commentPhotoRepository** %
.**% &
CreateAsync**& 1
(**1 2
commentPhotoDto**2 A
)**A B
;**B C
if-- 

(-- 
fanfic-- 
==-- 
null-- 
)-- 
{.. 	
throw// 
new// 
FanficException// %
(//% &
$"//& (
$str//( 5
"//5 6
)//6 7
;//7 8
}00 	
var22 
result22 
=22 
await22 
_commentRepository22 -
.22- .
AddCommentAsync22. =
(22= >

commentDto22> H
)22H I
;22I J
return44 
new44 

CommentDto44 
(44 
)44 
{55 	
FanficId66 
=66 

commentDto66 !
.66! "
FanficId66" *
,66* +
	CommentId77 
=77 
result77 
.77 
	CommentId77 (
,77( )
Content88 
=88 
result88 
.88 
Content88 $
,88$ %
	CreatedAt99 
=99 
result99 
.99 
	CreatedAt99 (
,99( )

AuthorName:: 
=:: 

authorName:: #
,::# $
Image;; 
=;; 
commentPhotoDto;; #
.;;# $
Image;;$ )
}<< 	
;<<	 

}== 
public?? 

async?? 
Task?? 
<?? 

CommentDto??  
>??  !
UpdateCommentAsync??" 4
(??4 5

CommentDto??5 ?

commentDto??@ J
,??J K
HttpRequest??L W
request??X _
)??_ `
{@@ 
varAA 

authorNameAA 
=AA 
_jwtTokenManagerAA )
.AA) * 
GetUserNameFromTokenAA* >
(AA> ?
requestAA? F
)AAF G
;AAG H
varBB 
commentBB 
=BB 
awaitBB 
_commentRepositoryBB .
.BB. /&
GetCommentByCommentIdAsyncBB/ I
(BBI J

commentDtoBBJ T
.BBT U
	CommentIdBBU ^
,BB^ _

authorNameBB` j
)BBj k
;BBk l
ifDD 

(DD 

authorNameDD 
!=DD 
commentDD !
.DD! "

AuthorNameDD" ,
)DD, -
throwEE 
newEE 
FanficExceptionEE %
(EE% &
$"EE& (
$strEE( E
"EEE F
)EEF G
;EEG H
commentGG 
.GG 
ContentGG 
=GG 

commentDtoGG $
.GG$ %
ContentGG% ,
??GG- /
commentGG0 7
.GG7 8
ContentGG8 ?
;GG? @
commentHH 
.HH 
ImageHH 
=HH 

commentDtoHH "
.HH" #
ImageHH# (
??HH) +
commentHH, 3
.HH3 4
ImageHH4 9
;HH9 :
varJJ 
resultJJ 
=JJ 
awaitJJ 
_commentRepositoryJJ -
.JJ- .
UpdateCommentAsyncJJ. @
(JJ@ A
commentJJA H
)JJH I
;JJI J
returnLL 
newLL 

CommentDtoLL 
(LL 
)LL 
{MM 	
FanficIdNN 
=NN 

commentDtoNN !
.NN! "
FanficIdNN" *
,NN* +
	CommentIdOO 
=OO 
resultOO 
.OO 
	CommentIdOO (
,OO( )
ContentPP 
=PP 
resultPP 
.PP 
ContentPP $
,PP$ %
	CreatedAtQQ 
=QQ 
resultQQ 
.QQ 
	CreatedAtQQ (
,QQ( )

AuthorNameRR 
=RR 

authorNameRR #
,RR# $
ImageSS 
=SS 
resultSS 
.SS 
ImageSS  
}TT 	
;TT	 

}UU 
publicWW 

asyncWW 
TaskWW 
DeleteCommentAsyncWW (
(WW( )
intWW) ,
idWW- /
,WW/ 0
HttpRequestWW1 <
requestWW= D
)WWD E
{XX 
varYY 

authorNameYY 
=YY 
_jwtTokenManagerYY )
.YY) * 
GetUserNameFromTokenYY* >
(YY> ?
requestYY? F
)YYF G
;YYG H
varZZ 
commentZZ 
=ZZ 
awaitZZ 
_commentRepositoryZZ .
.ZZ. /&
GetCommentByCommentIdAsyncZZ/ I
(ZZI J
idZZJ L
,ZZL M

authorNameZZN X
)ZZX Y
;ZZY Z
if\\ 

(\\ 

authorName\\ 
!=\\ 
comment\\ !
.\\! "

AuthorName\\" ,
)\\, -
throw]] 
new]] 
FanficException]] %
(]]% &
$"]]& (
$str]]( E
"]]E F
)]]F G
;]]G H
await__ 
_commentRepository__  
.__  !
DeleteCommentAsync__! 3
(__3 4
id__4 6
)__6 7
;__7 8
}`` 
publicbb 

asyncbb 
Taskbb 
<bb 

CommentDtobb  
>bb  !%
GetCommentByFanficIdAsyncbb" ;
(bb; <
intbb< ?
idbb@ B
,bbB C
HttpRequestbbD O
requestbbP W
)bbW X
{cc 
vardd 

authorNamedd 
=dd 
_jwtTokenManagerdd )
.dd) * 
GetUserNameFromTokendd* >
(dd> ?
requestdd? F
)ddF G
;ddG H
varee 
resultee 
=ee 
awaitee 
_commentRepositoryee -
.ee- .&
GetCommentByCommentIdAsyncee. H
(eeH I
ideeI K
,eeK L

authorNameeeM W
)eeW X
;eeX Y
returnff 
newff 

CommentDtoff 
(ff 
)ff 
{gg 	
FanficIdhh 
=hh 
resulthh 
.hh 
FanficIdhh &
,hh& '
	CommentIdii 
=ii 
resultii 
.ii 
	CommentIdii (
,ii( )
Contentjj 
=jj 
resultjj 
.jj 
Contentjj $
,jj$ %
	CreatedAtkk 
=kk 
resultkk 
.kk 
	CreatedAtkk (
,kk( )

AuthorNamell 
=ll 

authorNamell #
,ll# $
Imagemm 
=mm 
resultmm 
.mm 
Imagemm  
}nn 	
;nn	 

}oo 
publicqq 

asyncqq 
Taskqq 
<qq 
Listqq 
<qq 

CommentDtoqq %
>qq% &
>qq& '&
GetCommentsByFanficIdAsyncqq( B
(qqB C
intqqC F
fanficIdqqG O
,qqO P
HttpRequestqqQ \
requestqq] d
)qqd e
{rr 
varss 
resultss 
=ss 
awaitss 
_commentRepositoryss -
.ss- .&
GetCommentsByFanficIdAsyncss. H
(ssH I
fanficIdssI Q
)ssQ R
;ssR S
returnuu 
resultuu 
.uu 
Selectuu 
(uu 
commentuu $
=>uu% '
newuu( +

CommentDtouu, 6
(uu6 7
)uu7 8
{vv 	
FanficIdww 
=ww 
commentww 
.ww 
FanficIdww '
,ww' (
	CommentIdxx 
=xx 
commentxx 
.xx  
	CommentIdxx  )
,xx) *
Contentyy 
=yy 
commentyy 
.yy 
Contentyy %
,yy% &
	CreatedAtzz 
=zz 
commentzz 
.zz  
	CreatedAtzz  )
,zz) *

AuthorName{{ 
={{ 
comment{{  
.{{  !

AuthorName{{! +
,{{+ ,
Image|| 
=|| 
comment|| 
.|| 
Image|| !
}}} 	
)}}	 

.}}
 
ToList}} 
(}} 
)}} 
;}} 
}~~ 
public
�� 

async
�� 
Task
�� 
<
�� 

CommentDto
��  
>
��  !
ReplyCommentAsync
��" 3
(
��3 4

CommentDto
��4 >

commentDto
��? I
,
��I J
HttpRequest
��K V
request
��W ^
)
��^ _
{
�� 
var
�� 

authorName
�� 
=
�� 
_jwtTokenManager
�� )
.
��) *"
GetUserNameFromToken
��* >
(
��> ?
request
��? F
)
��F G
;
��G H
var
�� 
parentComment
�� 
=
�� 
await
�� ! 
_commentRepository
��" 4
.
��4 5(
GetCommentByCommentIdAsync
��5 O
(
��O P

commentDto
��P Z
.
��Z [
	CommentId
��[ d
,
��d e

authorName
��f p
)
��p q
;
��q r
if
�� 

(
�� 
parentComment
�� 
==
�� 
null
�� !
)
��! "
throw
��# (
new
��) ,
FanficException
��- <
(
��< =
$str
��= W
)
��W X
;
��X Y

commentDto
�� 
.
�� 

AuthorName
�� 
=
�� 

authorName
��  *
;
��* +

commentDto
�� 
.
�� 
	CreatedAt
�� 
=
�� 
DateTimeOffset
�� -
.
��- .
Now
��. 1
;
��1 2
var
�� 
commentPhotoDto
�� 
=
�� 
new
�� !
CommentPhotoDto
��" 1
{
�� 	
	CommentId
�� 
=
�� 

commentDto
�� "
.
��" #
	CommentId
��# ,
,
��, -
Image
�� 
=
�� 

commentDto
�� 
.
�� 
Image
�� $
}
�� 	
;
��	 

await
�� %
_commentPhotoRepository
�� %
.
��% &
CreateAsync
��& 1
(
��1 2
commentPhotoDto
��2 A
)
��A B
;
��B C
var
�� 
result
�� 
=
�� 
await
��  
_commentRepository
�� -
.
��- .
ReplyCommentAsync
��. ?
(
��? @

commentDto
��@ J
)
��J K
;
��K L
return
�� 
new
�� 

CommentDto
�� 
(
�� 
)
�� 
{
�� 	
FanficId
�� 
=
�� 

commentDto
�� !
.
��! "
FanficId
��" *
,
��* +
	CommentId
�� 
=
�� 
result
�� 
.
�� 
	CommentId
�� (
,
��( )
Content
�� 
=
�� 
result
�� 
.
�� 
Content
�� $
,
��$ %
	CreatedAt
�� 
=
�� 
result
�� 
.
�� 
	CreatedAt
�� (
,
��( )

AuthorName
�� 
=
�� 

authorName
�� #
,
��# $
Image
�� 
=
�� 
commentPhotoDto
�� #
.
��# $
Image
��$ )
}
�� 	
;
��	 

}
�� 
}�� �H
�C:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Infrastructure\Implementations\Fanfic\ChapterService.cs
	namespace		 	
FanPage		
 
.		 
Infrastructure		  
.		  !
Implementations		! 0
.		0 1
Fanfic		1 7
;		7 8
public 
class 
ChapterService 
: 
IChapter &
{ 
private 
readonly 
IChapterRepository '
_chapterRepository( :
;: ;
private 
readonly 
IMapper 
_mapper $
;$ %
private 
readonly 
IJwtTokenManager %
_jwtTokenManager& 6
;6 7
private 
readonly 
IFanficRepository &
_fanficRepository' 8
;8 9
public 

ChapterService 
( 
IChapterRepository ,
chapterRepository- >
,> ?
IMapper@ G
mapperH N
,N O
IJwtTokenManagerP `
jwtTokenManagera p
,p q
IFanficRepository 
fanficRepository *
)* +
{ 
_chapterRepository 
= 
chapterRepository .
;. /
_mapper 
= 
mapper 
; 
_jwtTokenManager 
= 
jwtTokenManager *
;* +
_fanficRepository 
= 
fanficRepository ,
;, -
} 
public 

async 
Task 
< 

ChapterDto  
>  !
CreateChapterAsync" 4
(4 5

ChapterDto5 ?

chapterDto@ J
,J K
HttpRequestL W
requestX _
)_ `
{ 
var 
fanfic 
= 
await 
_fanficRepository ,
., -
GetByIdAsync- 9
(9 :

chapterDto: D
.D E
FanficIdE M
)M N
;N O
var 
userName 
= 
_jwtTokenManager '
.' ( 
GetUserNameFromToken( <
(< =
request= D
)D E
;E F
if 

( 
fanfic 
. 

AuthorName 
!=  
userName! )
&&* ,
fanfic- 3
==4 6
null7 ;
); <
{   	
throw!! 
new!! 
FanficException!! %
(!!% &
$str!!& 4
)!!4 5
;!!5 6
}"" 	
var$$ 
result$$ 
=$$ 
await$$ 
_chapterRepository$$ -
.$$- .
CreateAsync$$. 9
($$9 :

chapterDto$$: D
)$$D E
;$$E F
return&& 
new&& 

ChapterDto&& 
(&& 
)&& 
{'' 	
	ChapterId(( 
=(( 
result(( 
.(( 
	ChapterId(( (
,((( )
FanficId)) 
=)) 
result)) 
.)) 
FanficId)) &
,))& '
Content** 
=** 
result** 
.** 
Content** $
,**$ %
Title++ 
=++ 
result++ 
.++ 
Title++  
},, 	
;,,	 

}-- 
public// 

async// 
Task// 
<// 

ChapterDto//  
>//  !
UpdateChapterAsync//" 4
(//4 5
int//5 8
	chapterId//9 B
,//B C

ChapterDto//D N

chapterDto//O Y
,//Y Z
HttpRequest//[ f
request//g n
)//n o
{00 
var11 
fanfic11 
=11 
await11 
_fanficRepository11 ,
.11, -
GetByIdAsync11- 9
(119 :

chapterDto11: D
.11D E
FanficId11E M
)11M N
;11N O
var22 
chapter22 
=22 
await22 
_chapterRepository22 .
.22. /
GetByIdAsync22/ ;
(22; <
	chapterId22< E
)22E F
;22F G
var33 
userName33 
=33 
_jwtTokenManager33 '
.33' ( 
GetUserNameFromToken33( <
(33< =
request33= D
)33D E
;33E F
if44 

(44 
fanfic44 
.44 

AuthorName44 
!=44  
userName44! )
&&44* ,
fanfic44- 3
==444 6
null447 ;
)44; <
{55 	
throw66 
new66 
FanficException66 %
(66% &
$str66& 4
)664 5
;665 6
}77 	

chapterDto99 
.99 
Content99 
=99 
chapter99 $
.99$ %
Content99% ,
??99- /

chapterDto990 :
.99: ;
Content99; B
;99B C

chapterDto:: 
.:: 
Title:: 
=:: 
chapter:: "
.::" #
Title::# (
??::) +

chapterDto::, 6
.::6 7
Title::7 <
;::< =
await<< 
_chapterRepository<<  
.<<  !
UpdateAsync<<! ,
(<<, -

chapterDto<<- 7
)<<7 8
;<<8 9
return>> 
new>> 

ChapterDto>> 
(>> 
)>> 
{?? 	
	ChapterId@@ 
=@@ 
	chapterId@@ !
,@@! "
FanficIdAA 
=AA 

chapterDtoAA !
.AA! "
FanficIdAA" *
,AA* +
ContentBB 
=BB 

chapterDtoBB  
.BB  !
ContentBB! (
,BB( )
TitleCC 
=CC 

chapterDtoCC 
.CC 
TitleCC $
}DD 	
;DD	 

}EE 
publicGG 

asyncGG 
TaskGG 
DeleteChapterAsyncGG (
(GG( )
intGG) ,
idGG- /
,GG/ 0
HttpRequestGG1 <
requestGG= D
)GGD E
{HH 
varII 
fanficII 
=II 
awaitII 
_fanficRepositoryII ,
.II, -
GetByIdAsyncII- 9
(II9 :
idII: <
)II< =
;II= >
varJJ 
userNameJJ 
=JJ 
_jwtTokenManagerJJ '
.JJ' ( 
GetUserNameFromTokenJJ( <
(JJ< =
requestJJ= D
)JJD E
;JJE F
ifKK 

(KK 
fanficKK 
.KK 

AuthorNameKK 
!=KK  
userNameKK! )
&&KK* ,
fanficKK- 3
==KK4 6
nullKK7 ;
)KK; <
{LL 	
throwMM 
newMM 
FanficExceptionMM %
(MM% &
$strMM& 4
)MM4 5
;MM5 6
}NN 	
awaitPP 
_chapterRepositoryPP  
.PP  !
DeleteAsyncPP! ,
(PP, -
idPP- /
)PP/ 0
;PP0 1
}QQ 
publicSS 

asyncSS 
TaskSS 
<SS 
ListSS 
<SS 

ChapterDtoSS %
>SS% &
>SS& ')
GetAllChaptersByFanficIdAsyncSS( E
(SSE F
intSSF I
fanficIdSSJ R
)SSR S
{TT 
varUU 
chaptersUU 
=UU 
awaitUU 
_chapterRepositoryUU /
.UU/ 0!
GetAllByFanficIdAsyncUU0 E
(UUE F
fanficIdUUF N
)UUN O
;UUO P
returnVV 
_mapperVV 
.VV 
MapVV 
<VV 
ListVV 
<VV  

ChapterDtoVV  *
>VV* +
>VV+ ,
(VV, -
chaptersVV- 5
)VV5 6
;VV6 7
}WW 
publicYY 

asyncYY 
TaskYY 
<YY 
ListYY 
<YY 

ChapterDtoYY %
>YY% &
>YY& '
GetAllChaptersAsyncYY( ;
(YY; <
)YY< =
{ZZ 
var[[ 
chapters[[ 
=[[ 
await[[ 
_chapterRepository[[ /
.[[/ 0
GetAllAsync[[0 ;
([[; <
)[[< =
;[[= >
return\\ 
_mapper\\ 
.\\ 
Map\\ 
<\\ 
List\\ 
<\\  

ChapterDto\\  *
>\\* +
>\\+ ,
(\\, -
chapters\\- 5
)\\5 6
;\\6 7
}]] 
public__ 

async__ 
Task__ 
<__ 

ChapterDto__  
>__  !
GetByIdAsync__" .
(__. /
int__/ 2
id__3 5
)__5 6
{`` 
varaa 
chapteraa 
=aa 
awaitaa 
_chapterRepositoryaa .
.aa. /
GetByIdAsyncaa/ ;
(aa; <
idaa< >
)aa> ?
;aa? @
returnbb 
_mapperbb 
.bb 
Mapbb 
<bb 

ChapterDtobb %
>bb% &
(bb& '
chapterbb' .
)bb. /
;bb/ 0
}cc 
}dd �3
�C:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Infrastructure\Implementations\Fanfic\CategoryService.cs
	namespace		 	
FanPage		
 
.		 
Infrastructure		  
.		  !
Implementations		! 0
.		0 1
Fanfic		1 7
;		7 8
public 
class 
CategoryService 
: 
	ICategory (
{ 
private 
readonly 
ICategoryRepository (
_categoryRepository) <
;< =
private 
readonly 
IFanficRepository &
_fanficRepository' 8
;8 9
private 
readonly 
IJwtTokenManager %
_jwtTokenManager& 6
;6 7
private 
readonly 
IMapper 
_mapper $
;$ %
public 

CategoryService 
( 
ICategoryRepository .
categoryRepository/ A
,A B
IFanficRepositoryC T
fanficRepositoryU e
,e f
IJwtTokenManager 
jwtTokenManager (
,( )
IMapper* 1
mapper2 8
)8 9
{ 
_categoryRepository 
= 
categoryRepository 0
;0 1
_fanficRepository 
= 
fanficRepository ,
;, -
_jwtTokenManager 
= 
jwtTokenManager *
;* +
_mapper 
= 
mapper 
; 
} 
public 

async 
Task 
< 
CategoryDto !
>! "
SetCategoryAsync# 3
(3 4
int4 7
fanficId8 @
,@ A
stringB H
categoryNameI U
,U V
HttpRequestW b
requestc j
)j k
{ 
var   
fanfic   
=   
await   
_fanficRepository   ,
.  , -
GetByIdAsync  - 9
(  9 :
fanficId  : B
)  B C
;  C D
var!! 
userName!! 
=!! 
_jwtTokenManager!! '
.!!' ( 
GetUserNameFromToken!!( <
(!!< =
request!!= D
)!!D E
;!!E F
var"" 
category"" 
="" 
await"" 
_categoryRepository"" 0
.""0 1
GetByNameAsync""1 ?
(""? @
categoryName""@ L
)""L M
;""M N
var## 

categoryId## 
=## 
category## !
.##! "

CategoryId##" ,
;##, -
var$$ !
categoryAlreadyFanfic$$ !
=$$" #
await$$$ )
_categoryRepository$$* =
.$$= >&
GetCategoryByFanficIdAsync$$> X
($$X Y
fanficId$$Y a
,$$a b

categoryId$$c m
)$$m n
;$$n o
if%% 

(%% 
fanfic%% 
.%% 

AuthorName%% 
!=%%  
userName%%! )
&&%%* ,
fanfic%%- 3
==%%4 6
null%%7 ;
)%%; <
{&& 	
throw'' 
new'' 
FanficException'' %
(''% &
$str''& 4
)''4 5
;''5 6
}(( 	
if** 

(** !
categoryAlreadyFanfic** !
!=**" $
null**% )
)**) *
{++ 	
throw,, 
new,, 
FanficException,, %
(,,% &
$str,,& >
),,> ?
;,,? @
}-- 	
if// 

(// 
category// 
==// 
null// 
)// 
{00 	
throw11 
new11 
FanficException11 %
(11% &
$str11& :
)11: ;
;11; <
}22 	
await44 
_categoryRepository44 !
.44! "$
AddCategoryToFanficAsync44" :
(44: ;
fanficId44; C
,44C D

categoryId44E O
)44O P
;44P Q
return66 
new66 
CategoryDto66 
(66 
)66  
{77 	

CategoryId88 
=88 
category88 !
.88! "

CategoryId88" ,
,88, -
Name99 
=99 
categoryName99 
}:: 	
;::	 

};; 
public== 

async== 
Task== 
DeleteCategoryAsync== )
(==) *
int==* -
fanficId==. 6
,==6 7
int==8 ;

categoryId==< F
,==F G
HttpRequest==H S
request==T [
)==[ \
{>> 
var?? 
fanfic?? 
=?? 
await?? 
_fanficRepository?? ,
.??, -
GetByIdAsync??- 9
(??9 :
fanficId??: B
)??B C
;??C D
var@@ 
userName@@ 
=@@ 
_jwtTokenManager@@ '
.@@' ( 
GetUserNameFromToken@@( <
(@@< =
request@@= D
)@@D E
;@@E F
ifAA 

(AA 
fanficAA 
.AA 

AuthorNameAA 
!=AA  
userNameAA! )
&&AA* ,
fanficAA- 3
==AA4 6
nullAA7 ;
)AA; <
{BB 	
throwCC 
newCC 
FanficExceptionCC %
(CC% &
$strCC& 4
)CC4 5
;CC5 6
}DD 	
awaitFF 
_categoryRepositoryFF !
.FF! ")
DeleteCategoryFromFanficAsyncFF" ?
(FF? @
fanficIdFF@ H
,FFH I

categoryIdFFJ T
)FFT U
;FFU V
}GG 
publicII 

asyncII 
TaskII 
<II 
ListII 
<II 
CategoryDtoII &
>II& '
>II' ( 
GetAllCategoryFanficII) =
(II= >
intII> A
fanficIdIIB J
)IIJ K
{JJ 
varKK 
reviewsKK 
=KK 
awaitKK 
_categoryRepositoryKK /
.KK/ 0)
GetAllCategoryByFanficIdAsyncKK0 M
(KKM N
fanficIdKKN V
)KKV W
;KKW X
returnLL 
_mapperLL 
.LL 
MapLL 
<LL 
ListLL 
<LL  
CategoryDtoLL  +
>LL+ ,
>LL, -
(LL- .
reviewsLL. 5
)LL5 6
;LL6 7
}MM 
}NN Ҩ
C:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Infrastructure\Implementations\Chat\ChatService.cs
	namespace		 	
FanPage		
 
.		 
Infrastructure		  
.		  !
Implementations		! 0
.		0 1
Chat		1 5
;		5 6
public 
class 
ChatService 
: 
IChat  
{ 
private 
readonly 
IChatRepository $
_chatRepository% 4
;4 5
private 
readonly 
IJwtTokenManager %
_jwtTokenManager& 6
;6 7
private 
readonly 
IAdmin 
_admin "
;" #
public 

ChatService 
( 
IChatRepository &
chatRepository' 5
,5 6
IJwtTokenManager7 G
jwtTokenManagerH W
,W X
IAdminY _
admin` e
)e f
{ 
_chatRepository 
= 
chatRepository (
;( )
_jwtTokenManager 
= 
jwtTokenManager *
;* +
_admin 
= 
admin 
; 
} 
public 

async 
Task 
< 
ChatDto 
> 
GetChatAsync +
(+ ,
int, /
id0 2
,2 3
string4 :
type; ?
,? @
HttpRequestA L
requestM T
)T U
{ 
var 
userName 
= 
_jwtTokenManager '
.' ( 
GetUserNameFromToken( <
(< =
request= D
)D E
;E F
if 

( 
userName 
== 
null 
) 
{ 	
throw 
new 
ChatException #
(# $
$"$ &
$str& 0
"0 1
)1 2
;2 3
} 	
var   
	chatUsers   
=   
await   
_chatRepository   -
.  - .
GetChatUsersAsync  . ?
(  ? @
id  @ B
)  B C
;  C D
var!! 
chat!! 
=!! 
await!! 
_chatRepository!! (
.!!( )
GetChatAsync!!) 5
(!!5 6
id!!6 8
,!!8 9
type!!: >
)!!> ?
;!!? @
return$$ 
new$$ 
ChatDto$$ 
{%% 	
Id&& 
=&& 
chat&& 
.&& 
Id&& 
,&& 
Type'' 
='' 
chat'' 
.'' 
Type'' 
,'' 
Name(( 
=(( 
chat(( 
.(( 
Name(( 
,(( 
	ChatUsers)) 
=)) 
	chatUsers)) !
.))! "
Select))" (
())( )
u))) *
=>))+ -
new)). 1
ChatUserDto))2 =
{** 
UserId++ 
=++ 
u++ 
.++ 
UserId++ !
,++! "
UserName,, 
=,, 
u,, 
.,, 
UserName,, %
}-- 
)-- 
.-- 
ToList-- 
(-- 
)-- 
}.. 	
;..	 

}// 
public22 

async22 
Task22 
<22 
List22 
<22 
ChatDto22 "
>22" #
>22# $
GetChatsAsync22% 2
(222 3
string223 9
type22: >
,22> ?
HttpRequest22@ K
request22L S
)22S T
{33 
var44 
userName44 
=44 
_jwtTokenManager44 '
.44' ( 
GetUserNameFromToken44( <
(44< =
request44= D
)44D E
;44E F
if55 

(55 
userName55 
==55 
null55 
)55 
{66 	
throw77 
new77 
ChatException77 #
(77# $
$"77$ &
$str77& 0
"770 1
)771 2
;772 3
}88 	
var:: 
chats:: 
=:: 
await:: 
_chatRepository:: )
.::) *
GetChatsAsync::* 7
(::7 8
type::8 <
)::< =
;::= >
return<< 
chats<< 
.<< 
Select<< 
(<< 
c<< 
=><<  
new<<! $
ChatDto<<% ,
{== 	
Id>> 
=>> 
c>> 
.>> 
Id>> 
,>> 
Type?? 
=?? 
c?? 
.?? 
Type?? 
,?? 
Name@@ 
=@@ 
c@@ 
.@@ 
Name@@ 
}AA 	
)AA	 

.AA
 
ToListAA 
(AA 
)AA 
;AA 
}BB 
publicDD 

asyncDD 
TaskDD 
CreateMessageAsyncDD (
(DD( )
intDD) ,
chatIdDD- 3
,DD3 4
stringDD5 ;
typeDD< @
,DD@ A

MessageDtoDDB L
messageDDM T
,DDT U
HttpRequestDDV a
requestDDb i
)DDi j
{EE 
varFF 
userNameFF 
=FF 
_jwtTokenManagerFF '
.FF' ( 
GetUserNameFromTokenFF( <
(FF< =
requestFF= D
)FFD E
;FFE F
varGG 
chatGG 
=GG 
awaitGG 
_chatRepositoryGG (
.GG( )
GetChatAsyncGG) 5
(GG5 6
chatIdGG6 <
,GG< =
typeGG> B
)GGB C
;GGC D
ifHH 

(HH 
userNameHH 
==HH 
nullHH 
||HH 
chatHH  $
==HH% '
nullHH( ,
)HH, -
{II 	
throwJJ 
newJJ 
ChatExceptionJJ #
(JJ# $
$"JJ$ &
$strJJ& 0
"JJ0 1
)JJ1 2
;JJ2 3
}KK 	
awaitMM 
_chatRepositoryMM 
.MM 
CreateMessageAsyncMM 0
(MM0 1
chatIdMM1 7
,MM7 8
messageMM9 @
)MM@ A
;MMA B
}NN 
publicPP 

asyncPP 
TaskPP 
<PP 
ChatDtoPP 
>PP 
CreateAsyncPP *
(PP* +
ChatDtoPP+ 2
chatPP3 7
,PP7 8
HttpRequestPP9 D
requestPPE L
)PPL M
{QQ 
varRR 
userNameRR 
=RR 
_jwtTokenManagerRR '
.RR' ( 
GetUserNameFromTokenRR( <
(RR< =
requestRR= D
)RRD E
;RRE F
ifSS 

(SS 
userNameSS 
==SS 
nullSS 
)SS 
{TT 	
throwUU 
newUU 
ChatExceptionUU #
(UU# $
$"UU$ &
$strUU& 0
"UU0 1
)UU1 2
;UU2 3
}VV 	
varXX 

chatEntityXX 
=XX 
awaitXX 
_chatRepositoryXX .
.XX. /
CreateAsyncXX/ :
(XX: ;
chatXX; ?
)XX? @
;XX@ A
returnYY 
newYY 
ChatDtoYY 
{ZZ 	
Id[[ 
=[[ 

chatEntity[[ 
.[[ 
Id[[ 
,[[ 
Type\\ 
=\\ 

chatEntity\\ 
.\\ 
Type\\ "
,\\" #
Name]] 
=]] 

chatEntity]] 
.]] 
Name]] "
}^^ 	
;^^	 

}__ 
publicaa 

asyncaa 
Taskaa 
<aa 
ChatDtoaa 
>aa 
UpdateAsyncaa *
(aa* +
ChatDtoaa+ 2
chataa3 7
,aa7 8
HttpRequestaa9 D
requestaaE L
)aaL M
{bb 
varcc 
userNamecc 
=cc 
_jwtTokenManagercc '
.cc' ( 
GetUserNameFromTokencc( <
(cc< =
requestcc= D
)ccD E
;ccE F
vardd 
userRoledd 
=dd 
awaitdd 
_admindd #
.dd# $
GetUserRoleAsyncdd$ 4
(dd4 5
userNamedd5 =
)dd= >
;dd> ?
varee 

chatEntityee 
=ee 
awaitee 
_chatRepositoryee .
.ee. /
GetChatAsyncee/ ;
(ee; <
chatee< @
.ee@ A
IdeeA C
,eeC D
chateeE I
.eeI J
TypeeeJ N
)eeN O
;eeO P
ifhh 

(hh 
userRolehh 
.hh 
Rolehh 
!=hh 
$strhh $
&&hh% '
userRolehh( 0
.hh0 1
Rolehh1 5
!=hh6 8
$strhh9 D
&&hhE G

chatEntityhhH R
.hhR S

AuthorNamehhS ]
!=hh^ `
userNamehha i
)hhi j
{ii 	
throwjj 
newjj 
ChatExceptionjj #
(jj# $
$"jj$ &
$strjj& C
"jjC D
)jjD E
;jjE F
}kk 	

chatEntitymm 
.mm 
Namemm 
=mm 
chatmm 
.mm 
Namemm #
??mm$ &

chatEntitymm' 1
.mm1 2
Namemm2 6
;mm6 7

chatEntitynn 
.nn 
Descriptionnn 
=nn  
chatnn! %
.nn% &
Descriptionnn& 1
??nn2 4

chatEntitynn5 ?
.nn? @
Descriptionnn@ K
;nnK L

chatEntityoo 
.oo 
Typeoo 
=oo 
chatoo 
.oo 
Typeoo #
??oo$ &

chatEntityoo' 1
.oo1 2
Typeoo2 6
;oo6 7
varqq 
resultqq 
=qq 
awaitqq 
_chatRepositoryqq *
.qq* +
UpdateAsyncqq+ 6
(qq6 7
chatqq7 ;
)qq; <
;qq< =
returntt 
newtt 
ChatDtott 
{uu 	
Idvv 
=vv 
resultvv 
.vv 
Idvv 
,vv 
Typeww 
=ww 
resultww 
.ww 
Typeww 
,ww 
Namexx 
=xx 
resultxx 
.xx 
Namexx 
}yy 	
;yy	 

}zz 
public}} 

async}} 
Task}} 
DeleteAsync}} !
(}}! "
int}}" %
id}}& (
,}}( )
string}}* 0
type}}1 5
,}}5 6
HttpRequest}}7 B
request}}C J
)}}J K
{~~ 
var 
userName 
= 
_jwtTokenManager '
.' ( 
GetUserNameFromToken( <
(< =
request= D
)D E
;E F
var
�� 
chat
�� 
=
�� 
await
�� 
_chatRepository
�� (
.
��( )
GetChatAsync
��) 5
(
��5 6
id
��6 8
,
��8 9
type
��: >
)
��> ?
;
��? @
if
�� 

(
�� 
chat
�� 
.
�� 

AuthorName
�� 
!=
�� 
userName
�� '
)
��' (
{
�� 	
throw
�� 
new
�� 
ChatException
�� #
(
��# $
$"
��$ &
$str
��& C
"
��C D
)
��D E
;
��E F
}
�� 	
await
�� 
_chatRepository
�� 
.
�� 
DeleteAsync
�� )
(
��) *
id
��* ,
)
��, -
;
��- .
}
�� 
public
�� 

async
�� 
Task
�� %
RemoveUserFromChatAsync
�� -
(
��- .
int
��. 1
chatId
��2 8
,
��8 9
string
��: @
userId
��A G
,
��G H
string
��I O
type
��P T
,
��T U
HttpRequest
��V a
request
��b i
)
��i j
{
�� 
var
�� 
userName
�� 
=
�� 
_jwtTokenManager
�� '
.
��' ("
GetUserNameFromToken
��( <
(
��< =
request
��= D
)
��D E
;
��E F
var
�� 
userRole
�� 
=
�� 
await
�� 
_admin
�� #
.
��# $
GetUserRoleAsync
��$ 4
(
��4 5
userName
��5 =
)
��= >
;
��> ?
var
�� 

chatEntity
�� 
=
�� 
await
�� 
_chatRepository
�� .
.
��. /
GetChatAsync
��/ ;
(
��; <
chatId
��< B
,
��B C
type
��D H
)
��H I
;
��I J
if
�� 

(
�� 
userRole
�� 
.
�� 
Role
�� 
!=
�� 
$str
�� $
&&
��% '
userRole
��( 0
.
��0 1
Role
��1 5
!=
��6 8
$str
��9 D
&&
��E G

chatEntity
��H R
.
��R S

AuthorName
��S ]
!=
��^ `
userName
��a i
)
��i j
{
�� 	
throw
�� 
new
�� 
ChatException
�� #
(
��# $
$"
��$ &
$str
��& C
"
��C D
)
��D E
;
��E F
}
�� 	
await
�� 
_chatRepository
�� 
.
�� %
RemoveUserFromChatAsync
�� 5
(
��5 6
chatId
��6 <
,
��< =
userId
��> D
)
��D E
;
��E F
}
�� 
public
�� 

async
�� 
Task
�� #
InviteUserToChatAsync
�� +
(
��+ ,
int
��, /
chatId
��0 6
,
��6 7
string
��8 >
userId
��? E
,
��E F
string
��G M
userName
��N V
,
��V W
HttpRequest
��X c
request
��d k
)
��k l
{
�� 
var
�� 
userNameFromToken
�� 
=
�� 
_jwtTokenManager
��  0
.
��0 1"
GetUserNameFromToken
��1 E
(
��E F
request
��F M
)
��M N
;
��N O
var
�� 
userRole
�� 
=
�� 
await
�� 
_admin
�� #
.
��# $
GetUserRoleAsync
��$ 4
(
��4 5
userNameFromToken
��5 F
)
��F G
;
��G H
if
�� 

(
�� 
userRole
�� 
.
�� 
Role
�� 
!=
�� 
$str
�� $
&&
��% '
userRole
��( 0
.
��0 1
Role
��1 5
!=
��6 8
$str
��9 D
)
��D E
{
�� 	
throw
�� 
new
�� 
ChatException
�� #
(
��# $
$"
��$ &
$str
��& C
"
��C D
)
��D E
;
��E F
}
�� 	
await
�� 
_chatRepository
�� 
.
�� #
InviteUserToChatAsync
�� 3
(
��3 4
chatId
��4 :
,
��: ;
userId
��< B
,
��B C
userName
��D L
)
��L M
;
��M N
}
�� 
public
�� 

async
�� 
Task
�� 
<
�� 
List
�� 
<
�� 
ChatDto
�� "
>
��" #
>
��# $!
GetChatRequestAsync
��% 8
(
��8 9
string
��9 ?
userId
��@ F
,
��F G
HttpRequest
��H S
request
��T [
)
��[ \
{
�� 
var
�� 
userNameFromToken
�� 
=
�� 
_jwtTokenManager
��  0
.
��0 1"
GetUserNameFromToken
��1 E
(
��E F
request
��F M
)
��M N
;
��N O
if
�� 

(
�� 
userNameFromToken
�� 
==
��  
null
��! %
)
��% &
{
�� 	
throw
�� 
new
�� 
ChatException
�� #
(
��# $
$"
��$ &
$str
��& 0
"
��0 1
)
��1 2
;
��2 3
}
�� 	
var
�� 
chats
�� 
=
�� 
await
�� 
_chatRepository
�� )
.
��) *!
GetChatRequestAsync
��* =
(
��= >
userId
��> D
)
��D E
;
��E F
return
�� 
chats
�� 
.
�� 
Select
�� 
(
�� 
c
�� 
=>
��  
new
��! $
ChatDto
��% ,
{
�� 	
Id
�� 
=
�� 
c
�� 
.
�� 
Id
�� 
,
�� 
Type
�� 
=
�� 
c
�� 
.
�� 
Type
�� 
,
�� 
Name
�� 
=
�� 
c
�� 
.
�� 
Name
�� 
}
�� 	
)
��	 

.
��
 
ToList
�� 
(
�� 
)
�� 
;
�� 
}
�� 
public
�� 

async
�� 
Task
�� #
AcceptUserToChatAsync
�� +
(
��+ ,
int
��, /
chatId
��0 6
,
��6 7
string
��8 >
userId
��? E
,
��E F
HttpRequest
��G R
request
��S Z
)
��Z [
{
�� 
var
�� 
userNameFromToken
�� 
=
�� 
_jwtTokenManager
��  0
.
��0 1"
GetUserNameFromToken
��1 E
(
��E F
request
��F M
)
��M N
;
��N O
var
�� 
chatRequest
�� 
=
�� 
await
�� 
_chatRepository
��  /
.
��/ 0!
GetChatRequestAsync
��0 C
(
��C D
userId
��D J
)
��J K
;
��K L
var
�� 
chat
�� 
=
�� 
chatRequest
�� 
.
�� 
FirstOrDefault
�� -
(
��- .
x
��. /
=>
��0 2
x
��3 4
.
��4 5
Id
��5 7
==
��8 :
chatId
��; A
)
��A B
;
��B C
if
�� 

(
�� 
chat
�� 
==
�� 
null
�� 
)
�� 
{
�� 	
throw
�� 
new
�� 
ChatException
�� #
(
��# $
$"
��$ &
$str
��& 0
"
��0 1
)
��1 2
;
��2 3
}
�� 	
if
�� 

(
�� 
userNameFromToken
�� 
==
��  
null
��! %
)
��% &
{
�� 	
throw
�� 
new
�� 
ChatException
�� #
(
��# $
$"
��$ &
$str
��& 0
"
��0 1
)
��1 2
;
��2 3
}
�� 	
await
�� 
_chatRepository
�� 
.
�� #
AcceptUserToChatAsync
�� 3
(
��3 4
chatId
��4 :
,
��: ;
userId
��< B
)
��B C
;
��C D
}
�� 
public
�� 

async
�� 
Task
�� $
DeclineUserToChatAsync
�� ,
(
��, -
int
��- 0
chatId
��1 7
,
��7 8
string
��9 ?
userId
��@ F
,
��F G
HttpRequest
��H S
request
��T [
)
��[ \
{
�� 
var
�� 
userNameFromToken
�� 
=
�� 
_jwtTokenManager
��  0
.
��0 1"
GetUserNameFromToken
��1 E
(
��E F
request
��F M
)
��M N
;
��N O
var
�� 
chatRequest
�� 
=
�� 
await
�� 
_chatRepository
��  /
.
��/ 0!
GetChatRequestAsync
��0 C
(
��C D
userId
��D J
)
��J K
;
��K L
var
�� 
chat
�� 
=
�� 
chatRequest
�� 
.
�� 
FirstOrDefault
�� -
(
��- .
x
��. /
=>
��0 2
x
��3 4
.
��4 5
Id
��5 7
==
��8 :
chatId
��; A
)
��A B
;
��B C
if
�� 

(
�� 
chat
�� 
==
�� 
null
�� 
)
�� 
{
�� 	
throw
�� 
new
�� 
ChatException
�� #
(
��# $
$"
��$ &
$str
��& 0
"
��0 1
)
��1 2
;
��2 3
}
�� 	
if
�� 

(
�� 
userNameFromToken
�� 
==
��  
null
��! %
)
��% &
{
�� 	
throw
�� 
new
�� 
ChatException
�� #
(
��# $
$"
��$ &
$str
��& 0
"
��0 1
)
��1 2
;
��2 3
}
�� 	
await
�� 
_chatRepository
�� 
.
�� $
DeclineUserToChatAsync
�� 4
(
��4 5
chatId
��5 ;
,
��; <
userId
��= C
)
��C D
;
��D E
}
�� 
public
�� 

Task
�� 
<
�� 
ChatDto
�� 
>
�� 
SearchChatAsync
�� (
(
��( )
string
��) /
search
��0 6
,
��6 7
HttpRequest
��8 C
request
��D K
)
��K L
{
�� 
throw
�� 
new
�� %
NotImplementedException
�� )
(
��) *
)
��* +
;
��+ ,
}
�� 
}�� �
~C:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Infrastructure\Extensions\EnumerableExtensions.cs
	namespace 	
FanPage
 
. 
Infrastructure  
.  !

Extensions! +
;+ ,
public 
static 
class  
EnumerableExtensions (
{ 
public 

static 
IEnumerable 
< 
T 
>  
OrEmptyIfNull! .
<. /
T/ 0
>0 1
(1 2
this2 6
IEnumerable7 B
<B C
TC D
>D E
?E F
sourceG M
)M N
{ 
return 
source 
?? 

Enumerable #
.# $
Empty$ )
<) *
T* +
>+ ,
(, -
)- .
;. /
} 
}		 �
�C:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Infrastructure\Configurations\DefaultUserConfiguration.cs
	namespace 	
FanPage
 
. 
Infrastructure  
.  !
Configurations! /
{ 
public 

class $
DefaultUserConfiguration )
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
string 
Password 
{  
get! $
;$ %
set& )
;) *
}+ ,
public		 
string		 
Email		 
{		 
get		 !
;		! "
set		# &
;		& '
}		( )
}

 
} �
�C:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Infrastructure\Configurations\ApplicationConfiguration.cs
	namespace 	
FanPage
 
. 
Infrastructure  
.  !
Configurations! /
{ 
public 

class $
ApplicationConfiguration )
{ 
public 
string 
? "
BaseApplicationAddress -
{. /
get0 3
;3 4
set5 8
;8 9
}: ;
} 
} 