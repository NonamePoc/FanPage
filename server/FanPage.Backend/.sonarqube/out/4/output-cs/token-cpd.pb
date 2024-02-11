˝
ÑC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Domain.Account\Repos\Interfaces\IUserPhotoRepository.cs
	namespace 	
FanPage
 
. 
Domain 
. 
Account  
.  !
Repos! &
.& '

Interfaces' 1
{ 
public 

	interface  
IUserPhotoRepository )
{ 
Task 
CreateAsync 
( 
PhotoDto !
createPhoto" -
)- .
;. /
Task		 
DeleteAsync		 
(		 
int		 
id		 
)		  
;		  !
Task 
UpdateAsync 
( 
int 
id 
,  
PhotoDto! )
updatePhoto* 5
)5 6
;6 7
} 
} ˘
ÅC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Domain.Account\Repos\Interfaces\IFriendRepository.cs
	namespace 	
FanPage
 
. 
Domain 
. 
Account  
.  !
Repos! &
.& '

Interfaces' 1
;1 2
public 
	interface 
IFriendRepository "
{ 
Task 
< 	
FriendRequestDto	 
> 
	AddFriend $
($ %
string% +
userId, 2
,2 3
string4 :
friendId; C
)C D
;D E
Task 
< 	
bool	 
> 
RemoveFriend 
( 
string "
userId# )
,) *
string+ 1
friendId2 :
): ;
;; <
Task		 
AcceptFriend			 
(		 
string		 
userId		 #
,		# $
string		% +
friendId		, 4
)		4 5
;		5 6
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
 
	FriendDto

 
>

 
>

 
FriendsList

 %
(

% &
string

& ,
userName

- 5
)

5 6
;

6 7
Task 
< 	
bool	 
> 

CancelSend 
( 
string  
userId! '
,' (
string) /
friendId0 8
)8 9
;9 :
Task 
< 	
List	 
< 
FriendRequestDto 
> 
>  
GetFriendRequests! 2
(2 3
string3 9
userId: @
)@ A
;A B
Task 
< 	
List	 
< 
FriendRequestDto 
> 
>  
GetUserRequests! 0
(0 1
string1 7
friendId8 @
)@ A
;A B
} È
ÉC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Domain.Account\Repos\Interfaces\IFollowerRepository.cs
	namespace 	
FanPage
 
. 
Domain 
. 
Account  
.  !
Repos! &
.& '

Interfaces' 1
;1 2
public 
	interface 
IFollowerRepository $
{ 
Task 
< 	
List	 
< 
FollowerDto 
> 
> 
FollowerList (
(( )
string) /
userId0 6
)6 7
;7 8
Task		 
<		 	
bool			 
>		 
	Subscribe		 
(		 
int		 

followerId		 '
,		' (
string		) /
userId		0 6
)		6 7
;		7 8
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
 
Unsubscribe

 
(

 
int

 

followerId

 )
,

) *
string

+ 1
userId

2 8
)

8 9
;

9 :
} ´
êC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Domain.Account\Repos\Interfaces\ICustomizationSettingsRepository.cs
	namespace 	
FanPage
 
. 
Domain 
. 
Account  
.  !
Repos! &
.& '

Interfaces' 1
;1 2
public 
	interface ,
 ICustomizationSettingsRepository 1
{ 
Task 
ChangeBannerImage	 
( 
int #
customizationSettingsId 6
,6 7
byte8 <
[< =
]= >
bannerImage? J
)J K
;K L
Task

 
<

 	
int

	 
>

 '
CreateCustomizationSettings

 )
(

) *
)

* +
;

+ ,
Task 
< 	 
CustomUserSettingDto	 
> $
GetCustomizationSettings 7
(7 8
int8 ;#
customizationSettingsId< S
)S T
;T U
} ⁄
ÉC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Domain.Account\Repos\Interfaces\IBookmarkRepository.cs
	namespace 	
FanPage
 
. 
Domain 
. 
Account  
.  !
Repos! &
.& '

Interfaces' 1
;1 2
public 
	interface 
IBookmarkRepository $
{ 
Task 
< 	
List	 
< 
BookmarkDto 
> 
> 
BookmarkList (
(( )
string) /
userId0 6
)6 7
;7 8
Task		 
<		 	
bool			 
>		 
Add		 
(		 
string		 
userId		  
,		  !
int		" %
fanficId		& .
)		. /
;		/ 0
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
 
Delete

 
(

 
string

 
userId

 #
,

# $
int

% (
fanficId

) 1
)

1 2
;

2 3
} Œ
}C:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Domain.Account\Repos\Impl\UserPhotoRepository.cs
	namespace 	
FanPage
 
. 
Domain 
. 
Account  
.  !
Repos! &
.& '
Impl' +
{ 
public		 

class		 
UserPhotoRepository		 $
:		% & 
IUserPhotoRepository		' ;
{

 
private 
readonly 
UserContext $
_context% -
;- .
private 
readonly 
IMapper  
_mapper! (
;( )
public 
UserPhotoRepository "
(" #
UserContext# .
context/ 6
,6 7
IMapper8 ?
mapper@ F
)F G
{ 	
_context 
= 
context 
; 
_mapper 
= 
mapper 
; 
} 	
public 
Task 
CreateAsync 
(  
PhotoDto  (
createPhoto) 4
)4 5
{ 	
var 
photoMap 
= 
_mapper "
." #
Map# &
<& '
Photo' ,
>, -
(- .
createPhoto. 9
)9 :
;: ;
_context 
. 
Photos 
. 
Add 
(  
photoMap  (
)( )
;) *
return 
_context 
. 
SaveChangesAsync ,
(, -
)- .
;. /
} 	
public 
Task 
DeleteAsync 
(  
int  #
id$ &
)& '
{ 	
var 
photo 
= 
_context  
.  !
Photos! '
.' (
FirstOrDefault( 6
(6 7
x7 8
=>9 ;
x< =
.= >
Id> @
==A C
idD F
)F G
;G H
_context 
. 
Photos 
. 
Remove "
(" #
photo# (
)( )
;) *
return 
_context 
. 
SaveChangesAsync ,
(, -
)- .
;. /
}   	
public"" 
Task"" 
UpdateAsync"" 
(""  
int""  #
id""$ &
,""& '
PhotoDto""( 0
updatePhoto""1 <
)""< =
{## 	
var$$ 
photo$$ 
=$$ 
_context$$  
.$$  !
Photos$$! '
.$$' (
FirstOrDefault$$( 6
($$6 7
x$$7 8
=>$$9 ;
x$$< =
.$$= >
Id$$> @
==$$A C
id$$D F
)$$F G
;$$G H
photo%% 
.%% 
Image%% 
=%% 
updatePhoto%% %
.%%% &
Image%%& +
;%%+ ,
return&& 
_context&& 
.&& 
SaveChangesAsync&& ,
(&&, -
)&&- .
;&&. /
}'' 	
}(( 
})) âM
zC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Domain.Account\Repos\Impl\FriendRepository.cs
	namespace 	
FanPage
 
. 
Domain 
. 
Account  
.  !
Repos! &
.& '
Impl' +
{		 
public

 

class

 
FriendRepository

 !
:

" #
IFriendRepository

$ 5
{ 
private 
readonly 
UserContext $
_userContext% 1
;1 2
private 
readonly 
IMapper  
_mapper! (
;( )
public 
FriendRepository 
(  
UserContext  +
userContext, 7
,7 8
IMapper9 @
mapperA G
)G H
{ 	
_userContext 
= 
userContext &
;& '
_mapper 
= 
mapper 
; 
} 	
public 
async 
Task 
< 
List 
< 
	FriendDto (
>( )
>) *
FriendsList+ 6
(6 7
string7 =
userId> D
)D E
{ 	
var 
friendRequests 
=  
await! &
_userContext' 3
.3 4
Friendships4 ?
. 
Where 
( 
fr 
=> 
fr 
.  
UserId  &
==' )
userId* 0
)0 1
. 
ToListAsync 
( 
) 
; 
return 
_mapper 
. 
Map 
< 
List #
<# $
	FriendDto$ -
>- .
>. /
(/ 0
friendRequests0 >
)> ?
;? @
} 	
public 
async 
Task 
< 
FriendRequestDto *
>* +
	AddFriend, 5
(5 6
string6 <
userId= C
,C D
stringE K
friendIdL T
)T U
{ 	
var   
existingRequest   
=    !
await  " '
_userContext  ( 4
.  4 5
FriendRequests  5 C
.!! 
FirstOrDefaultAsync!! $
(!!$ %
fr!!% '
=>!!( *
fr!!+ -
.!!- .
UserId!!. 4
==!!5 7
userId!!8 >
&&!!? A
fr!!B D
.!!D E
FriendId!!E M
==!!N P
friendId!!Q Y
)!!Y Z
;!!Z [
if## 
(## 
existingRequest## 
!=##  "
null### '
)##' (
return##) /
null##0 4
;##4 5
var$$ 
newFriendRequest$$  
=$$! "
new$$# &
FriendRequest$$' 4
{%% 
UserId&& 
=&& 
userId&& 
,&&  
FriendId'' 
='' 
friendId'' #
,''# $
IsApproving(( 
=(( 
false(( #
})) 
;)) 
await** 
_userContext** 
.** 
FriendRequests** -
.**- .
AddAsync**. 6
(**6 7
newFriendRequest**7 G
)**G H
;**H I
await++ 
_userContext++ 
.++ 
SaveChangesAsync++ /
(++/ 0
)++0 1
;++1 2
return,, 
_mapper,, 
.,, 
Map,, 
<,, 
FriendRequestDto,, /
>,,/ 0
(,,0 1
newFriendRequest,,1 A
),,A B
;,,B C
}-- 	
public// 
async// 
Task// 
<// 
bool// 
>// 
RemoveFriend//  ,
(//, -
string//- 3
userId//4 :
,//: ;
string//< B
friendId//C K
)//K L
{00 	
var11 

friendShip11 
=11 
await11 "
_userContext11# /
.11/ 0
Friendships110 ;
.22 
FirstOrDefaultAsync22 $
(22$ %
fr22% '
=>22( *
fr22+ -
.22- .
UserId22. 4
==225 7
userId228 >
&&22? A
fr22B D
.22D E
FriendId22E M
==22N P
friendId22Q Y
)22Y Z
;22Z [
_userContext44 
.44 
Friendships44 $
.44$ %
Remove44% +
(44+ ,

friendShip44, 6
??447 9
throw44: ?
new44@ C%
InvalidOperationException44D ]
(44] ^
$str44^ n
)44n o
)44o p
;44p q
await55 
_userContext55 
.55 
SaveChangesAsync55 /
(55/ 0
)550 1
;551 2
return66 
true66 
;66 
}77 	
public99 
async99 
Task99 
AcceptFriend99 &
(99& '
string99' -
userId99. 4
,994 5
string996 <
friendId99= E
)99E F
{:: 	
var;; 
friendRequest;; 
=;; 
await;;  %
_userContext;;& 2
.;;2 3
FriendRequests;;3 A
.<< 
FirstOrDefaultAsync<< $
(<<$ %
fr<<% '
=><<( *
fr<<+ -
.<<- .
UserId<<. 4
==<<5 7
friendId<<8 @
&&<<A C
fr<<D F
.<<F G
FriendId<<G O
==<<P R
userId<<S Y
)<<Y Z
;<<Z [
_userContext== 
.== 
FriendRequests== '
.==' (
Remove==( .
(==. /
friendRequest==/ <
??=== ?
throw==@ E
new==F I%
InvalidOperationException==J c
(==c d
$str==d t
)==t u
)==u v
;==v w
var?? 

friendship?? 
=?? 
new??  

Friendship??! +
{@@ 
UserIdAA 
=AA 
userIdAA 
,AA  
FriendIdBB 
=BB 
friendIdBB #
}CC 
;CC 
_userContextDD 
.DD 
FriendshipsDD $
.DD$ %
AddDD% (
(DD( )

friendshipDD) 3
)DD3 4
;DD4 5
awaitEE 
_userContextEE 
.EE 
SaveChangesAsyncEE /
(EE/ 0
)EE0 1
;EE1 2
}FF 	
publicHH 
asyncHH 
TaskHH 
<HH 
boolHH 
>HH 

CancelSendHH  *
(HH* +
stringHH+ 1
userIdHH2 8
,HH8 9
stringHH: @
friendIdHHA I
)HHI J
{II 	
varJJ 
friendRequestJJ 
=JJ 
awaitJJ  %
_userContextJJ& 2
.JJ2 3
FriendRequestsJJ3 A
.KK 
FirstOrDefaultAsyncKK $
(KK$ %
frKK% '
=>KK( *
frKK+ -
.KK- .
UserIdKK. 4
==KK5 7
userIdKK8 >
&&KK? A
frKKB D
.KKD E
FriendIdKKE M
==KKN P
friendIdKKQ Y
)KKY Z
;KKZ [
_userContextMM 
.MM 
FriendRequestsMM '
.MM' (
RemoveMM( .
(MM. /
friendRequestMM/ <
??MM= ?
throwMM@ E
newMMF I%
InvalidOperationExceptionMMJ c
(MMc d
$strMMd t
)MMt u
)MMu v
;MMv w
awaitNN 
_userContextNN 
.NN 
SaveChangesAsyncNN /
(NN/ 0
)NN0 1
;NN1 2
returnOO 
trueOO 
;OO 
}PP 	
publicRR 
asyncRR 
TaskRR 
<RR 
ListRR 
<RR 
FriendRequestDtoRR /
>RR/ 0
>RR0 1
GetFriendRequestsRR2 C
(RRC D
stringRRD J
userIdRRK Q
)RRQ R
{SS 	
varTT 
friendRequestsTT 
=TT  
awaitTT! &
_userContextTT' 3
.TT3 4
FriendRequestsTT4 B
.UU 
WhereUU 
(UU 
frUU 
=>UU 
frUU 
.UU  
UserIdUU  &
==UU' )
userIdUU* 0
)UU0 1
.VV 
ToListAsyncVV 
(VV 
)VV 
;VV 
returnXX 
_mapperXX 
.XX 
MapXX 
<XX 
ListXX #
<XX# $
FriendRequestDtoXX$ 4
>XX4 5
>XX5 6
(XX6 7
friendRequestsXX7 E
)XXE F
;XXF G
}YY 	
public[[ 
async[[ 
Task[[ 
<[[ 
List[[ 
<[[ 
FriendRequestDto[[ /
>[[/ 0
>[[0 1
GetUserRequests[[2 A
([[A B
string[[B H
friendId[[I Q
)[[Q R
{\\ 	
var]] "
receivedFriendRequests]] &
=]]' (
await]]) .
_userContext]]/ ;
.]]; <
FriendRequests]]< J
.^^ 
Where^^ 
(^^ 
fr^^ 
=>^^ 
fr^^ 
.^^  
FriendId^^  (
==^^) +
friendId^^, 4
)^^4 5
.__ 
ToListAsync__ 
(__ 
)__ 
;__ 
returnaa 
_mapperaa 
.aa 
Mapaa 
<aa 
Listaa #
<aa# $
FriendRequestDtoaa$ 4
>aa4 5
>aa5 6
(aa6 7"
receivedFriendRequestsaa7 M
)aaM N
;aaN O
}bb 	
}cc 
}dd ≤#
|C:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Domain.Account\Repos\Impl\FollowerRepository.cs
	namespace 	
FanPage
 
. 
Domain 
. 
Account  
.  !
Repos! &
.& '
Impl' +
;+ ,
public

 
class

 
FollowerRepository

 
:

  !
IFollowerRepository

" 5
{ 
private 
readonly 
UserContext  
_userContext! -
;- .
private 
readonly 
IMapper 
_mapper $
;$ %
public 

FollowerRepository 
( 
UserContext )
userContext* 5
,5 6
IMapper7 >
mapper? E
)E F
{ 
_userContext 
= 
userContext "
;" #
_mapper 
= 
mapper 
; 
} 
public 

async 
Task 
< 
List 
< 
FollowerDto &
>& '
>' (
FollowerList) 5
(5 6
string6 <
userId= C
)C D
{ 
var 
	followers 
= 
await 
_userContext *
.* +
	Followers+ 4
. 
Where 
( 
user 
=> 
user 
.  
UserId  &
==' )
userId* 0
)0 1
. 
ToListAsync 
( 
) 
; 
return 
_mapper 
. 
Map 
< 
List 
<  
FollowerDto  +
>+ ,
>, -
(- .
	followers. 7
)7 8
;8 9
} 
public 

async 
Task 
< 
bool 
> 
	Subscribe %
(% &
int& )

followerId* 4
,4 5
string6 <
userId= C
)C D
{ 
await   
_userContext   
.   
	Followers   $
.!! 
FirstOrDefaultAsync!!  
(!!  !
sub!!! $
=>!!% '
sub!!( +
.!!+ ,
UserId!!, 2
==!!3 5
userId!!6 <
&&!!= ?
sub!!@ C
.!!C D

FollowerId!!D N
==!!O Q

followerId!!R \
)!!\ ]
;!!] ^
var"" 
newSub"" 
="" 
new"" 
Follower"" !
{## 	
UserId$$ 
=$$ 
userId$$ 
,$$ 

FollowerId%% 
=%% 

followerId%% #
}&& 	
;&&	 

_userContext'' 
.'' 
	Followers'' 
.'' 
Add'' "
(''" #
newSub''# )
)'') *
;''* +
await(( 
_userContext(( 
.(( 
SaveChangesAsync(( +
(((+ ,
)((, -
;((- .
return)) 
true)) 
;)) 
}** 
public,, 

async,, 
Task,, 
<,, 
bool,, 
>,, 
Unsubscribe,, '
(,,' (
int,,( +

followerId,,, 6
,,,6 7
string,,8 >
userId,,? E
),,E F
{-- 
var.. 
unsub.. 
=.. 
await.. 
_userContext.. &
...& '
	Followers..' 0
.// 
FirstOrDefaultAsync//  
(//  !
sub//! $
=>//% '
sub//( +
.//+ ,
UserId//, 2
==//3 5
userId//6 <
&&//= ?
sub//@ C
.//C D

FollowerId//D N
==//O Q

followerId//R \
)//\ ]
;//] ^
_userContext00 
.00 
	Followers00 
.00 
Remove00 %
(00% &
unsub00& +
??00, .
throw00/ 4
new005 8%
InvalidOperationException009 R
(00R S
$str00S _
)00_ `
)00` a
;00a b
await11 
_userContext11 
.11 
SaveChangesAsync11 +
(11+ ,
)11, -
;11- .
return22 
true22 
;22 
}33 
}44 ä
âC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Domain.Account\Repos\Impl\CustomizationSettingsRepository.cs
	namespace 	
FanPage
 
. 
Domain 
. 
Account  
.  !
Repos! &
.& '
Impl' +
;+ ,
public

 
class

 +
CustomizationSettingsRepository

 ,
:

- .,
 ICustomizationSettingsRepository

/ O
{ 
private 
readonly 
UserContext  
_context! )
;) *
private 
readonly 
IMapper 
_mapper $
;$ %
public 
+
CustomizationSettingsRepository *
(* +
UserContext+ 6
context7 >
,> ?
IMapper@ G
mapperH N
)N O
{ 
_context 
= 
context 
; 
_mapper 
= 
mapper 
; 
} 
public 

async 
Task 
ChangeBannerImage '
(' (
int( +#
customizationSettingsId, C
,C D
byteE I
[I J
]J K
bannerImageL W
)W X
{ 
var !
customizationSettings !
=" #
await$ )
_context* 2
.2 3!
CustomizationSettings3 H
. 
FirstOrDefaultAsync  
(  !
cs! #
=>$ &
cs' )
.) *#
CustomizationSettingsId* A
==B D#
customizationSettingsIdE \
)\ ]
;] ^
if 

( !
customizationSettings !
!=" $
null% )
)) *!
customizationSettings+ @
.@ A
BannerImageA L
=M N
bannerImageO Z
;Z [
await 
_context 
. 
SaveChangesAsync '
(' (
)( )
;) *
} 
public 

async 
Task 
< 
int 
> '
CreateCustomizationSettings 6
(6 7
)7 8
{ 
var !
customizationSettings !
=" #
new$ '!
CustomizationSettings( =
(= >
)> ?
;? @
_context   
.   !
CustomizationSettings   &
.  & '
Add  ' *
(  * +!
customizationSettings  + @
)  @ A
;  A B
await!! 
_context!! 
.!! 
SaveChangesAsync!! '
(!!' (
)!!( )
;!!) *
return## !
customizationSettings## $
.##$ %#
CustomizationSettingsId##% <
;##< =
}$$ 
public&& 

async&& 
Task&& 
<&&  
CustomUserSettingDto&& *
>&&* +$
GetCustomizationSettings&&, D
(&&D E
int&&E H#
customizationSettingsId&&I `
)&&` a
{'' 
var(( !
customizationSettings(( !
=((" #
await(($ )
_context((* 2
.((2 3!
CustomizationSettings((3 H
.)) 
FirstOrDefaultAsync))  
())  !
cs))! #
=>))$ &
cs))' )
.))) *#
CustomizationSettingsId))* A
==))B D#
customizationSettingsId))E \
)))\ ]
;))] ^
return** 
_mapper** 
.** 
Map** 
<**  
CustomUserSettingDto** /
>**/ 0
(**0 1!
customizationSettings**1 F
)**F G
;**G H
}++ 
},, ∑'
}C:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Domain.Account\Repos\Impl\BookmarksRepository.cs
	namespace 	
FanPage
 
. 
Domain 
. 
Account  
.  !
Repos! &
.& '
Impl' +
{		 
public

 

class

 
BookmarksRepository

 $
:

% &
IBookmarkRepository

' :
{ 
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
UserContext $
_userContext% 1
;1 2
public 
BookmarksRepository "
(" #
IMapper# *
mapper+ 1
,1 2
UserContext3 >
userContext? J
)J K
{ 	
_mapper 
= 
mapper 
; 
_userContext 
= 
userContext &
;& '
} 	
public 
async 
Task 
< 
List 
< 
BookmarkDto *
>* +
>+ ,
BookmarkList- 9
(9 :
string: @
userIdA G
)G H
{ 	
var 
	bookmarks 
= 
await !
_userContext" .
.. /
	Bookmarks/ 8
.8 9
Where9 >
(> ?
w? @
=>A C
wD E
.E F
UserIdF L
==M O
userIdP V
)V W
.W X
ToListAsyncX c
(c d
)d e
;e f
return 
_mapper 
. 
Map 
< 
List #
<# $
BookmarkDto$ /
>/ 0
>0 1
(1 2
	bookmarks2 ;
); <
;< =
} 	
public 
async 
Task 
< 
bool 
> 
Add  #
(# $
string$ *
userId+ 1
,1 2
int3 6
fanficId7 ?
)? @
{ 	
var 
bookmarkExists 
=  
await 
_userContext "
." #
	Bookmarks# ,
., -
Where- 2
(2 3
w3 4
=>5 7
w8 9
.9 :
UserId: @
==A C
userIdD J
&&K M
wN O
.O P
FanficReadingIdP _
==` b
fanficIdc k
)k l
. 
ToListAsync  
(  !
)! "
;" #
if!! 
(!! 
bookmarkExists!! 
!=!! !
null!!" &
&&!!' )
bookmarkExists!!* 8
.!!8 9
Count!!9 >
>!!? @
$num!!A B
)!!B C
{"" 
throw## 
new## 
	Exception## #
(### $
$str##$ =
)##= >
;##> ?
}$$ 
await&& 
_userContext&& 
.&& 
	Bookmarks&& (
.&&( )
AddAsync&&) 1
(&&1 2
new&&2 5
Bookmark&&6 >
{'' 
UserId(( 
=(( 
userId(( 
,((  
FanficReadingId)) 
=))  !
fanficId))" *
}** 
)** 
;** 
await,, 
_userContext,, 
.,, 
SaveChangesAsync,, /
(,,/ 0
),,0 1
;,,1 2
return-- 
true-- 
;-- 
}.. 	
public00 
async00 
Task00 
<00 
bool00 
>00 
Delete00  &
(00& '
string00' -
userId00. 4
,004 5
int006 9
fanficId00: B
)00B C
{11 	
var22 
remove22 
=22 
await22 
_userContext22 +
.22+ ,
	Bookmarks22, 5
.33 
FirstOrDefaultAsync33 $
(33$ %
marks33% *
=>33+ -
marks33. 3
.333 4
UserId334 :
==33; =
userId33> D
&&33E G
marks33H M
.33M N
FanficReadingId33N ]
==33^ `
fanficId33a i
)33i j
;33j k
if44 
(44 
remove44 
==44 
null44 
)44 
throw44  %
new44& )
	Exception44* 3
(443 4
$str444 H
)44H I
;44I J
_userContext55 
.55 
	Bookmarks55 "
.55" #
Remove55# )
(55) *
remove55* 0
)550 1
;551 2
await66 
_userContext66 
.66 
SaveChangesAsync66 /
(66/ 0
)660 1
;661 2
return77 
true77 
;77 
}88 	
}99 
}:: Ù
{C:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Domain.Account\Migrations\20240204142322_v2.cs
	namespace 	
FanPage
 
. 
Domain 
. 
Account  
.  !

Migrations! +
{ 
public 

partial 
class 
v2 
: 
	Migration '
{		 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
	AddColumn &
<& '
byte' +
[+ ,
], -
>- .
(. /
name 
: 
$str #
,# $
table 
: 
$str .
,. /
type 
: 
$str 
, 
nullable 
: 
true 
) 
;  
} 	
	protected 
override 
void 
Down  $
($ %
MigrationBuilder% 5
migrationBuilder6 F
)F G
{ 	
migrationBuilder 
. 

DropColumn '
(' (
name 
: 
$str #
,# $
table 
: 
$str .
). /
;/ 0
} 	
} 
} ØÉ
{C:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Domain.Account\Migrations\20240126172741_v1.cs
	namespace 	
FanPage
 
. 
Domain 
. 
Account  
.  !

Migrations! +
{ 
public

 

partial

 
class

 
v1

 
:

 
	Migration

 '
{ 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
CreateTable (
(( )
name 
: 
$str #
,# $
columns 
: 
table 
=> !
new" %
{ 
Id 
= 
table 
. 
Column %
<% &
string& ,
>, -
(- .
type. 2
:2 3
$str4 :
,: ;
nullable< D
:D E
falseF K
)K L
,L M
Name 
= 
table  
.  !
Column! '
<' (
string( .
>. /
(/ 0
type0 4
:4 5
$str6 N
,N O
	maxLengthP Y
:Y Z
$num[ ^
,^ _
nullable` h
:h i
truej n
)n o
,o p
NormalizedName "
=# $
table% *
.* +
Column+ 1
<1 2
string2 8
>8 9
(9 :
type: >
:> ?
$str@ X
,X Y
	maxLengthZ c
:c d
$nume h
,h i
nullablej r
:r s
truet x
)x y
,y z
ConcurrencyStamp $
=% &
table' ,
., -
Column- 3
<3 4
string4 :
>: ;
(; <
type< @
:@ A
$strB H
,H I
nullableJ R
:R S
trueT X
)X Y
} 
, 
constraints 
: 
table "
=># %
{ 
table 
. 

PrimaryKey $
($ %
$str% 5
,5 6
x7 8
=>9 ;
x< =
.= >
Id> @
)@ A
;A B
} 
) 
; 
migrationBuilder 
. 
CreateTable (
(( )
name 
: 
$str -
,- .
columns 
: 
table 
=> !
new" %
{   #
CustomizationSettingsId!! +
=!!, -
table!!. 3
.!!3 4
Column!!4 :
<!!: ;
int!!; >
>!!> ?
(!!? @
type!!@ D
:!!D E
$str!!F O
,!!O P
nullable!!Q Y
:!!Y Z
false!![ `
)!!` a
."" 

Annotation"" #
(""# $
$str""$ D
,""D E)
NpgsqlValueGenerationStrategy""F c
.""c d#
IdentityByDefaultColumn""d {
)""{ |
}## 
,## 
constraints$$ 
:$$ 
table$$ "
=>$$# %
{%% 
table&& 
.&& 

PrimaryKey&& $
(&&$ %
$str&&% ?
,&&? @
x&&A B
=>&&C E
x&&F G
.&&G H#
CustomizationSettingsId&&H _
)&&_ `
;&&` a
}'' 
)'' 
;'' 
migrationBuilder)) 
.)) 
CreateTable)) (
())( )
name** 
:** 
$str** (
,**( )
columns++ 
:++ 
table++ 
=>++ !
new++" %
{,, 
Id-- 
=-- 
table-- 
.-- 
Column-- %
<--% &
int--& )
>--) *
(--* +
type--+ /
:--/ 0
$str--1 :
,--: ;
nullable--< D
:--D E
false--F K
)--K L
... 

Annotation.. #
(..# $
$str..$ D
,..D E)
NpgsqlValueGenerationStrategy..F c
...c d#
IdentityByDefaultColumn..d {
)..{ |
,..| }
RoleId// 
=// 
table// "
.//" #
Column//# )
<//) *
string//* 0
>//0 1
(//1 2
type//2 6
://6 7
$str//8 >
,//> ?
nullable//@ H
://H I
false//J O
)//O P
,//P Q
	ClaimType00 
=00 
table00  %
.00% &
Column00& ,
<00, -
string00- 3
>003 4
(004 5
type005 9
:009 :
$str00; A
,00A B
nullable00C K
:00K L
true00M Q
)00Q R
,00R S

ClaimValue11 
=11  
table11! &
.11& '
Column11' -
<11- .
string11. 4
>114 5
(115 6
type116 :
:11: ;
$str11< B
,11B C
nullable11D L
:11L M
true11N R
)11R S
}22 
,22 
constraints33 
:33 
table33 "
=>33# %
{44 
table55 
.55 

PrimaryKey55 $
(55$ %
$str55% :
,55: ;
x55< =
=>55> @
x55A B
.55B C
Id55C E
)55E F
;55F G
table66 
.66 

ForeignKey66 $
(66$ %
name77 
:77 
$str77 F
,77F G
column88 
:88 
x88  !
=>88" $
x88% &
.88& '
RoleId88' -
,88- .
principalTable99 &
:99& '
$str99( 5
,995 6
principalColumn:: '
:::' (
$str::) -
,::- .
onDelete;;  
:;;  !
ReferentialAction;;" 3
.;;3 4
Cascade;;4 ;
);;; <
;;;< =
}<< 
)<< 
;<< 
migrationBuilder>> 
.>> 
CreateTable>> (
(>>( )
name?? 
:?? 
$str?? #
,??# $
columns@@ 
:@@ 
table@@ 
=>@@ !
new@@" %
{AA 
IdBB 
=BB 
tableBB 
.BB 
ColumnBB %
<BB% &
stringBB& ,
>BB, -
(BB- .
typeBB. 2
:BB2 3
$strBB4 :
,BB: ;
nullableBB< D
:BBD E
falseBBF K
)BBK L
,BBL M

UserAvatarCC 
=CC  
tableCC! &
.CC& '
ColumnCC' -
<CC- .
byteCC. 2
[CC2 3
]CC3 4
>CC4 5
(CC5 6
typeCC6 :
:CC: ;
$strCC< C
,CCC D
nullableCCE M
:CCM N
trueCCO S
)CCS T
,CCT U
WhoBanDD 
=DD 
tableDD "
.DD" #
ColumnDD# )
<DD) *
stringDD* 0
>DD0 1
(DD1 2
typeDD2 6
:DD6 7
$strDD8 >
,DD> ?
nullableDD@ H
:DDH I
falseDDJ O
)DDO P
,DDP Q#
CustomizationSettingsIdEE +
=EE, -
tableEE. 3
.EE3 4
ColumnEE4 :
<EE: ;
intEE; >
>EE> ?
(EE? @
typeEE@ D
:EED E
$strEEF O
,EEO P
nullableEEQ Y
:EEY Z
falseEE[ `
)EE` a
,EEa b
UserNameFF 
=FF 
tableFF $
.FF$ %
ColumnFF% +
<FF+ ,
stringFF, 2
>FF2 3
(FF3 4
typeFF4 8
:FF8 9
$strFF: R
,FFR S
	maxLengthFFT ]
:FF] ^
$numFF_ b
,FFb c
nullableFFd l
:FFl m
trueFFn r
)FFr s
,FFs t
NormalizedUserNameGG &
=GG' (
tableGG) .
.GG. /
ColumnGG/ 5
<GG5 6
stringGG6 <
>GG< =
(GG= >
typeGG> B
:GGB C
$strGGD \
,GG\ ]
	maxLengthGG^ g
:GGg h
$numGGi l
,GGl m
nullableGGn v
:GGv w
trueGGx |
)GG| }
,GG} ~
EmailHH 
=HH 
tableHH !
.HH! "
ColumnHH" (
<HH( )
stringHH) /
>HH/ 0
(HH0 1
typeHH1 5
:HH5 6
$strHH7 O
,HHO P
	maxLengthHHQ Z
:HHZ [
$numHH\ _
,HH_ `
nullableHHa i
:HHi j
trueHHk o
)HHo p
,HHp q
NormalizedEmailII #
=II$ %
tableII& +
.II+ ,
ColumnII, 2
<II2 3
stringII3 9
>II9 :
(II: ;
typeII; ?
:II? @
$strIIA Y
,IIY Z
	maxLengthII[ d
:IId e
$numIIf i
,IIi j
nullableIIk s
:IIs t
trueIIu y
)IIy z
,IIz {
EmailConfirmedJJ "
=JJ# $
tableJJ% *
.JJ* +
ColumnJJ+ 1
<JJ1 2
boolJJ2 6
>JJ6 7
(JJ7 8
typeJJ8 <
:JJ< =
$strJJ> G
,JJG H
nullableJJI Q
:JJQ R
falseJJS X
)JJX Y
,JJY Z
PasswordHashKK  
=KK! "
tableKK# (
.KK( )
ColumnKK) /
<KK/ 0
stringKK0 6
>KK6 7
(KK7 8
typeKK8 <
:KK< =
$strKK> D
,KKD E
nullableKKF N
:KKN O
trueKKP T
)KKT U
,KKU V
SecurityStampLL !
=LL" #
tableLL$ )
.LL) *
ColumnLL* 0
<LL0 1
stringLL1 7
>LL7 8
(LL8 9
typeLL9 =
:LL= >
$strLL? E
,LLE F
nullableLLG O
:LLO P
trueLLQ U
)LLU V
,LLV W
ConcurrencyStampMM $
=MM% &
tableMM' ,
.MM, -
ColumnMM- 3
<MM3 4
stringMM4 :
>MM: ;
(MM; <
typeMM< @
:MM@ A
$strMMB H
,MMH I
nullableMMJ R
:MMR S
trueMMT X
)MMX Y
,MMY Z
PhoneNumberNN 
=NN  !
tableNN" '
.NN' (
ColumnNN( .
<NN. /
stringNN/ 5
>NN5 6
(NN6 7
typeNN7 ;
:NN; <
$strNN= C
,NNC D
nullableNNE M
:NNM N
trueNNO S
)NNS T
,NNT U 
PhoneNumberConfirmedOO (
=OO) *
tableOO+ 0
.OO0 1
ColumnOO1 7
<OO7 8
boolOO8 <
>OO< =
(OO= >
typeOO> B
:OOB C
$strOOD M
,OOM N
nullableOOO W
:OOW X
falseOOY ^
)OO^ _
,OO_ `
TwoFactorEnabledPP $
=PP% &
tablePP' ,
.PP, -
ColumnPP- 3
<PP3 4
boolPP4 8
>PP8 9
(PP9 :
typePP: >
:PP> ?
$strPP@ I
,PPI J
nullablePPK S
:PPS T
falsePPU Z
)PPZ [
,PP[ \

LockoutEndQQ 
=QQ  
tableQQ! &
.QQ& '
ColumnQQ' -
<QQ- .
DateTimeOffsetQQ. <
>QQ< =
(QQ= >
typeQQ> B
:QQB C
$strQQD ^
,QQ^ _
nullableQQ` h
:QQh i
trueQQj n
)QQn o
,QQo p
LockoutEnabledRR "
=RR# $
tableRR% *
.RR* +
ColumnRR+ 1
<RR1 2
boolRR2 6
>RR6 7
(RR7 8
typeRR8 <
:RR< =
$strRR> G
,RRG H
nullableRRI Q
:RRQ R
falseRRS X
)RRX Y
,RRY Z
AccessFailedCountSS %
=SS& '
tableSS( -
.SS- .
ColumnSS. 4
<SS4 5
intSS5 8
>SS8 9
(SS9 :
typeSS: >
:SS> ?
$strSS@ I
,SSI J
nullableSSK S
:SSS T
falseSSU Z
)SSZ [
}TT 
,TT 
constraintsUU 
:UU 
tableUU "
=>UU# %
{VV 
tableWW 
.WW 

PrimaryKeyWW $
(WW$ %
$strWW% 5
,WW5 6
xWW7 8
=>WW9 ;
xWW< =
.WW= >
IdWW> @
)WW@ A
;WWA B
tableXX 
.XX 

ForeignKeyXX $
(XX$ %
nameYY 
:YY 
$strYY \
,YY\ ]
columnZZ 
:ZZ 
xZZ  !
=>ZZ" $
xZZ% &
.ZZ& '#
CustomizationSettingsIdZZ' >
,ZZ> ?
principalTable[[ &
:[[& '
$str[[( ?
,[[? @
principalColumn\\ '
:\\' (
$str\\) B
,\\B C
onDelete]]  
:]]  !
ReferentialAction]]" 3
.]]3 4
Cascade]]4 ;
)]]; <
;]]< =
}^^ 
)^^ 
;^^ 
migrationBuilder`` 
.`` 
CreateTable`` (
(``( )
nameaa 
:aa 
$straa  
,aa  !
columnsbb 
:bb 
tablebb 
=>bb !
newbb" %
{cc 
	StickerIddd 
=dd 
tabledd  %
.dd% &
Columndd& ,
<dd, -
intdd- 0
>dd0 1
(dd1 2
typedd2 6
:dd6 7
$strdd8 A
,ddA B
nullableddC K
:ddK L
falseddM R
)ddR S
.ee 

Annotationee #
(ee# $
$stree$ D
,eeD E)
NpgsqlValueGenerationStrategyeeF c
.eec d#
IdentityByDefaultColumneed {
)ee{ |
,ee| }
Imageff 
=ff 
tableff !
.ff! "
Columnff" (
<ff( )
byteff) -
[ff- .
]ff. /
>ff/ 0
(ff0 1
typeff1 5
:ff5 6
$strff7 >
,ff> ?
nullableff@ H
:ffH I
falseffJ O
)ffO P
,ffP Q#
CustomizationSettingsIdgg +
=gg, -
tablegg. 3
.gg3 4
Columngg4 :
<gg: ;
intgg; >
>gg> ?
(gg? @
typegg@ D
:ggD E
$strggF O
,ggO P
nullableggQ Y
:ggY Z
falsegg[ `
)gg` a
}hh 
,hh 
constraintsii 
:ii 
tableii "
=>ii# %
{jj 
tablekk 
.kk 

PrimaryKeykk $
(kk$ %
$strkk% 2
,kk2 3
xkk4 5
=>kk6 8
xkk9 :
.kk: ;
	StickerIdkk; D
)kkD E
;kkE F
tablell 
.ll 

ForeignKeyll $
(ll$ %
namemm 
:mm 
$strmm Y
,mmY Z
columnnn 
:nn 
xnn  !
=>nn" $
xnn% &
.nn& '#
CustomizationSettingsIdnn' >
,nn> ?
principalTableoo &
:oo& '
$stroo( ?
,oo? @
principalColumnpp '
:pp' (
$strpp) B
,ppB C
onDeleteqq  
:qq  !
ReferentialActionqq" 3
.qq3 4
Cascadeqq4 ;
)qq; <
;qq< =
}rr 
)rr 
;rr 
migrationBuildertt 
.tt 
CreateTablett (
(tt( )
nameuu 
:uu 
$struu (
,uu( )
columnsvv 
:vv 
tablevv 
=>vv !
newvv" %
{ww 
Idxx 
=xx 
tablexx 
.xx 
Columnxx %
<xx% &
intxx& )
>xx) *
(xx* +
typexx+ /
:xx/ 0
$strxx1 :
,xx: ;
nullablexx< D
:xxD E
falsexxF K
)xxK L
.yy 

Annotationyy #
(yy# $
$stryy$ D
,yyD E)
NpgsqlValueGenerationStrategyyyF c
.yyc d#
IdentityByDefaultColumnyyd {
)yy{ |
,yy| }
UserIdzz 
=zz 
tablezz "
.zz" #
Columnzz# )
<zz) *
stringzz* 0
>zz0 1
(zz1 2
typezz2 6
:zz6 7
$strzz8 >
,zz> ?
nullablezz@ H
:zzH I
falsezzJ O
)zzO P
,zzP Q
	ClaimType{{ 
={{ 
table{{  %
.{{% &
Column{{& ,
<{{, -
string{{- 3
>{{3 4
({{4 5
type{{5 9
:{{9 :
$str{{; A
,{{A B
nullable{{C K
:{{K L
true{{M Q
){{Q R
,{{R S

ClaimValue|| 
=||  
table||! &
.||& '
Column||' -
<||- .
string||. 4
>||4 5
(||5 6
type||6 :
:||: ;
$str||< B
,||B C
nullable||D L
:||L M
true||N R
)||R S
}}} 
,}} 
constraints~~ 
:~~ 
table~~ "
=>~~# %
{ 
table
ÄÄ 
.
ÄÄ 

PrimaryKey
ÄÄ $
(
ÄÄ$ %
$str
ÄÄ% :
,
ÄÄ: ;
x
ÄÄ< =
=>
ÄÄ> @
x
ÄÄA B
.
ÄÄB C
Id
ÄÄC E
)
ÄÄE F
;
ÄÄF G
table
ÅÅ 
.
ÅÅ 

ForeignKey
ÅÅ $
(
ÅÅ$ %
name
ÇÇ 
:
ÇÇ 
$str
ÇÇ F
,
ÇÇF G
column
ÉÉ 
:
ÉÉ 
x
ÉÉ  !
=>
ÉÉ" $
x
ÉÉ% &
.
ÉÉ& '
UserId
ÉÉ' -
,
ÉÉ- .
principalTable
ÑÑ &
:
ÑÑ& '
$str
ÑÑ( 5
,
ÑÑ5 6
principalColumn
ÖÖ '
:
ÖÖ' (
$str
ÖÖ) -
,
ÖÖ- .
onDelete
ÜÜ  
:
ÜÜ  !
ReferentialAction
ÜÜ" 3
.
ÜÜ3 4
Cascade
ÜÜ4 ;
)
ÜÜ; <
;
ÜÜ< =
}
áá 
)
áá 
;
áá 
migrationBuilder
ââ 
.
ââ 
CreateTable
ââ (
(
ââ( )
name
ää 
:
ää 
$str
ää (
,
ää( )
columns
ãã 
:
ãã 
table
ãã 
=>
ãã !
new
ãã" %
{
åå 
LoginProvider
çç !
=
çç" #
table
çç$ )
.
çç) *
Column
çç* 0
<
çç0 1
string
çç1 7
>
çç7 8
(
çç8 9
type
çç9 =
:
çç= >
$str
çç? E
,
ççE F
nullable
ççG O
:
ççO P
false
ççQ V
)
ççV W
,
ççW X
ProviderKey
éé 
=
éé  !
table
éé" '
.
éé' (
Column
éé( .
<
éé. /
string
éé/ 5
>
éé5 6
(
éé6 7
type
éé7 ;
:
éé; <
$str
éé= C
,
ééC D
nullable
ééE M
:
ééM N
false
ééO T
)
ééT U
,
ééU V!
ProviderDisplayName
èè '
=
èè( )
table
èè* /
.
èè/ 0
Column
èè0 6
<
èè6 7
string
èè7 =
>
èè= >
(
èè> ?
type
èè? C
:
èèC D
$str
èèE K
,
èèK L
nullable
èèM U
:
èèU V
true
èèW [
)
èè[ \
,
èè\ ]
UserId
êê 
=
êê 
table
êê "
.
êê" #
Column
êê# )
<
êê) *
string
êê* 0
>
êê0 1
(
êê1 2
type
êê2 6
:
êê6 7
$str
êê8 >
,
êê> ?
nullable
êê@ H
:
êêH I
false
êêJ O
)
êêO P
}
ëë 
,
ëë 
constraints
íí 
:
íí 
table
íí "
=>
íí# %
{
ìì 
table
îî 
.
îî 

PrimaryKey
îî $
(
îî$ %
$str
îî% :
,
îî: ;
x
îî< =
=>
îî> @
new
îîA D
{
îîE F
x
îîG H
.
îîH I
LoginProvider
îîI V
,
îîV W
x
îîX Y
.
îîY Z
ProviderKey
îîZ e
}
îîf g
)
îîg h
;
îîh i
table
ïï 
.
ïï 

ForeignKey
ïï $
(
ïï$ %
name
ññ 
:
ññ 
$str
ññ F
,
ññF G
column
óó 
:
óó 
x
óó  !
=>
óó" $
x
óó% &
.
óó& '
UserId
óó' -
,
óó- .
principalTable
òò &
:
òò& '
$str
òò( 5
,
òò5 6
principalColumn
ôô '
:
ôô' (
$str
ôô) -
,
ôô- .
onDelete
öö  
:
öö  !
ReferentialAction
öö" 3
.
öö3 4
Cascade
öö4 ;
)
öö; <
;
öö< =
}
õõ 
)
õõ 
;
õõ 
migrationBuilder
ùù 
.
ùù 
CreateTable
ùù (
(
ùù( )
name
ûû 
:
ûû 
$str
ûû '
,
ûû' (
columns
üü 
:
üü 
table
üü 
=>
üü !
new
üü" %
{
†† 
UserId
°° 
=
°° 
table
°° "
.
°°" #
Column
°°# )
<
°°) *
string
°°* 0
>
°°0 1
(
°°1 2
type
°°2 6
:
°°6 7
$str
°°8 >
,
°°> ?
nullable
°°@ H
:
°°H I
false
°°J O
)
°°O P
,
°°P Q
RoleId
¢¢ 
=
¢¢ 
table
¢¢ "
.
¢¢" #
Column
¢¢# )
<
¢¢) *
string
¢¢* 0
>
¢¢0 1
(
¢¢1 2
type
¢¢2 6
:
¢¢6 7
$str
¢¢8 >
,
¢¢> ?
nullable
¢¢@ H
:
¢¢H I
false
¢¢J O
)
¢¢O P
}
££ 
,
££ 
constraints
§§ 
:
§§ 
table
§§ "
=>
§§# %
{
•• 
table
¶¶ 
.
¶¶ 

PrimaryKey
¶¶ $
(
¶¶$ %
$str
¶¶% 9
,
¶¶9 :
x
¶¶; <
=>
¶¶= ?
new
¶¶@ C
{
¶¶D E
x
¶¶F G
.
¶¶G H
UserId
¶¶H N
,
¶¶N O
x
¶¶P Q
.
¶¶Q R
RoleId
¶¶R X
}
¶¶Y Z
)
¶¶Z [
;
¶¶[ \
table
ßß 
.
ßß 

ForeignKey
ßß $
(
ßß$ %
name
®® 
:
®® 
$str
®® E
,
®®E F
column
©© 
:
©© 
x
©©  !
=>
©©" $
x
©©% &
.
©©& '
RoleId
©©' -
,
©©- .
principalTable
™™ &
:
™™& '
$str
™™( 5
,
™™5 6
principalColumn
´´ '
:
´´' (
$str
´´) -
,
´´- .
onDelete
¨¨  
:
¨¨  !
ReferentialAction
¨¨" 3
.
¨¨3 4
Cascade
¨¨4 ;
)
¨¨; <
;
¨¨< =
table
≠≠ 
.
≠≠ 

ForeignKey
≠≠ $
(
≠≠$ %
name
ÆÆ 
:
ÆÆ 
$str
ÆÆ E
,
ÆÆE F
column
ØØ 
:
ØØ 
x
ØØ  !
=>
ØØ" $
x
ØØ% &
.
ØØ& '
UserId
ØØ' -
,
ØØ- .
principalTable
∞∞ &
:
∞∞& '
$str
∞∞( 5
,
∞∞5 6
principalColumn
±± '
:
±±' (
$str
±±) -
,
±±- .
onDelete
≤≤  
:
≤≤  !
ReferentialAction
≤≤" 3
.
≤≤3 4
Cascade
≤≤4 ;
)
≤≤; <
;
≤≤< =
}
≥≥ 
)
≥≥ 
;
≥≥ 
migrationBuilder
µµ 
.
µµ 
CreateTable
µµ (
(
µµ( )
name
∂∂ 
:
∂∂ 
$str
∂∂ (
,
∂∂( )
columns
∑∑ 
:
∑∑ 
table
∑∑ 
=>
∑∑ !
new
∑∑" %
{
∏∏ 
UserId
ππ 
=
ππ 
table
ππ "
.
ππ" #
Column
ππ# )
<
ππ) *
string
ππ* 0
>
ππ0 1
(
ππ1 2
type
ππ2 6
:
ππ6 7
$str
ππ8 >
,
ππ> ?
nullable
ππ@ H
:
ππH I
false
ππJ O
)
ππO P
,
ππP Q
LoginProvider
∫∫ !
=
∫∫" #
table
∫∫$ )
.
∫∫) *
Column
∫∫* 0
<
∫∫0 1
string
∫∫1 7
>
∫∫7 8
(
∫∫8 9
type
∫∫9 =
:
∫∫= >
$str
∫∫? E
,
∫∫E F
nullable
∫∫G O
:
∫∫O P
false
∫∫Q V
)
∫∫V W
,
∫∫W X
Name
ªª 
=
ªª 
table
ªª  
.
ªª  !
Column
ªª! '
<
ªª' (
string
ªª( .
>
ªª. /
(
ªª/ 0
type
ªª0 4
:
ªª4 5
$str
ªª6 <
,
ªª< =
nullable
ªª> F
:
ªªF G
false
ªªH M
)
ªªM N
,
ªªN O
Value
ºº 
=
ºº 
table
ºº !
.
ºº! "
Column
ºº" (
<
ºº( )
string
ºº) /
>
ºº/ 0
(
ºº0 1
type
ºº1 5
:
ºº5 6
$str
ºº7 =
,
ºº= >
nullable
ºº? G
:
ººG H
true
ººI M
)
ººM N
}
ΩΩ 
,
ΩΩ 
constraints
ææ 
:
ææ 
table
ææ "
=>
ææ# %
{
øø 
table
¿¿ 
.
¿¿ 

PrimaryKey
¿¿ $
(
¿¿$ %
$str
¿¿% :
,
¿¿: ;
x
¿¿< =
=>
¿¿> @
new
¿¿A D
{
¿¿E F
x
¿¿G H
.
¿¿H I
UserId
¿¿I O
,
¿¿O P
x
¿¿Q R
.
¿¿R S
LoginProvider
¿¿S `
,
¿¿` a
x
¿¿b c
.
¿¿c d
Name
¿¿d h
}
¿¿i j
)
¿¿j k
;
¿¿k l
table
¡¡ 
.
¡¡ 

ForeignKey
¡¡ $
(
¡¡$ %
name
¬¬ 
:
¬¬ 
$str
¬¬ F
,
¬¬F G
column
√√ 
:
√√ 
x
√√  !
=>
√√" $
x
√√% &
.
√√& '
UserId
√√' -
,
√√- .
principalTable
ƒƒ &
:
ƒƒ& '
$str
ƒƒ( 5
,
ƒƒ5 6
principalColumn
≈≈ '
:
≈≈' (
$str
≈≈) -
,
≈≈- .
onDelete
∆∆  
:
∆∆  !
ReferentialAction
∆∆" 3
.
∆∆3 4
Cascade
∆∆4 ;
)
∆∆; <
;
∆∆< =
}
«« 
)
«« 
;
«« 
migrationBuilder
…… 
.
…… 
CreateTable
…… (
(
……( )
name
   
:
   
$str
   !
,
  ! "
columns
ÀÀ 
:
ÀÀ 
table
ÀÀ 
=>
ÀÀ !
new
ÀÀ" %
{
ÃÃ 

BookmarkId
ÕÕ 
=
ÕÕ  
table
ÕÕ! &
.
ÕÕ& '
Column
ÕÕ' -
<
ÕÕ- .
int
ÕÕ. 1
>
ÕÕ1 2
(
ÕÕ2 3
type
ÕÕ3 7
:
ÕÕ7 8
$str
ÕÕ9 B
,
ÕÕB C
nullable
ÕÕD L
:
ÕÕL M
false
ÕÕN S
)
ÕÕS T
.
ŒŒ 

Annotation
ŒŒ #
(
ŒŒ# $
$str
ŒŒ$ D
,
ŒŒD E+
NpgsqlValueGenerationStrategy
ŒŒF c
.
ŒŒc d%
IdentityByDefaultColumn
ŒŒd {
)
ŒŒ{ |
,
ŒŒ| }
Stage
œœ 
=
œœ 
table
œœ !
.
œœ! "
Column
œœ" (
<
œœ( )
string
œœ) /
>
œœ/ 0
(
œœ0 1
type
œœ1 5
:
œœ5 6
$str
œœ7 =
,
œœ= >
nullable
œœ? G
:
œœG H
true
œœI M
)
œœM N
,
œœN O
UserId
–– 
=
–– 
table
–– "
.
––" #
Column
––# )
<
––) *
string
––* 0
>
––0 1
(
––1 2
type
––2 6
:
––6 7
$str
––8 >
,
––> ?
nullable
––@ H
:
––H I
false
––J O
)
––O P
,
––P Q
FanficReadingId
—— #
=
——$ %
table
——& +
.
——+ ,
Column
——, 2
<
——2 3
int
——3 6
>
——6 7
(
——7 8
type
——8 <
:
——< =
$str
——> G
,
——G H
nullable
——I Q
:
——Q R
false
——S X
)
——X Y
}
““ 
,
““ 
constraints
”” 
:
”” 
table
”” "
=>
””# %
{
‘‘ 
table
’’ 
.
’’ 

PrimaryKey
’’ $
(
’’$ %
$str
’’% 3
,
’’3 4
x
’’5 6
=>
’’7 9
x
’’: ;
.
’’; <

BookmarkId
’’< F
)
’’F G
;
’’G H
table
÷÷ 
.
÷÷ 

ForeignKey
÷÷ $
(
÷÷$ %
name
◊◊ 
:
◊◊ 
$str
◊◊ ?
,
◊◊? @
column
ÿÿ 
:
ÿÿ 
x
ÿÿ  !
=>
ÿÿ" $
x
ÿÿ% &
.
ÿÿ& '
UserId
ÿÿ' -
,
ÿÿ- .
principalTable
ŸŸ &
:
ŸŸ& '
$str
ŸŸ( 5
,
ŸŸ5 6
principalColumn
⁄⁄ '
:
⁄⁄' (
$str
⁄⁄) -
,
⁄⁄- .
onDelete
€€  
:
€€  !
ReferentialAction
€€" 3
.
€€3 4
Cascade
€€4 ;
)
€€; <
;
€€< =
}
‹‹ 
)
‹‹ 
;
‹‹ 
migrationBuilder
ﬁﬁ 
.
ﬁﬁ 
CreateTable
ﬁﬁ (
(
ﬁﬁ( )
name
ﬂﬂ 
:
ﬂﬂ 
$str
ﬂﬂ !
,
ﬂﬂ! "
columns
‡‡ 
:
‡‡ 
table
‡‡ 
=>
‡‡ !
new
‡‡" %
{
·· 

FollowerId
‚‚ 
=
‚‚  
table
‚‚! &
.
‚‚& '
Column
‚‚' -
<
‚‚- .
int
‚‚. 1
>
‚‚1 2
(
‚‚2 3
type
‚‚3 7
:
‚‚7 8
$str
‚‚9 B
,
‚‚B C
nullable
‚‚D L
:
‚‚L M
false
‚‚N S
)
‚‚S T
.
„„ 

Annotation
„„ #
(
„„# $
$str
„„$ D
,
„„D E+
NpgsqlValueGenerationStrategy
„„F c
.
„„c d%
IdentityByDefaultColumn
„„d {
)
„„{ |
,
„„| }
UserId
‰‰ 
=
‰‰ 
table
‰‰ "
.
‰‰" #
Column
‰‰# )
<
‰‰) *
string
‰‰* 0
>
‰‰0 1
(
‰‰1 2
type
‰‰2 6
:
‰‰6 7
$str
‰‰8 >
,
‰‰> ?
nullable
‰‰@ H
:
‰‰H I
true
‰‰J N
)
‰‰N O
}
ÂÂ 
,
ÂÂ 
constraints
ÊÊ 
:
ÊÊ 
table
ÊÊ "
=>
ÊÊ# %
{
ÁÁ 
table
ËË 
.
ËË 

PrimaryKey
ËË $
(
ËË$ %
$str
ËË% 3
,
ËË3 4
x
ËË5 6
=>
ËË7 9
x
ËË: ;
.
ËË; <

FollowerId
ËË< F
)
ËËF G
;
ËËG H
table
ÈÈ 
.
ÈÈ 

ForeignKey
ÈÈ $
(
ÈÈ$ %
name
ÍÍ 
:
ÍÍ 
$str
ÍÍ ?
,
ÍÍ? @
column
ÎÎ 
:
ÎÎ 
x
ÎÎ  !
=>
ÎÎ" $
x
ÎÎ% &
.
ÎÎ& '
UserId
ÎÎ' -
,
ÎÎ- .
principalTable
ÏÏ &
:
ÏÏ& '
$str
ÏÏ( 5
,
ÏÏ5 6
principalColumn
ÌÌ '
:
ÌÌ' (
$str
ÌÌ) -
)
ÌÌ- .
;
ÌÌ. /
}
ÓÓ 
)
ÓÓ 
;
ÓÓ 
migrationBuilder
 
.
 
CreateTable
 (
(
( )
name
ÒÒ 
:
ÒÒ 
$str
ÒÒ &
,
ÒÒ& '
columns
ÚÚ 
:
ÚÚ 
table
ÚÚ 
=>
ÚÚ !
new
ÚÚ" %
{
ÛÛ 
FriendRequestId
ÙÙ #
=
ÙÙ$ %
table
ÙÙ& +
.
ÙÙ+ ,
Column
ÙÙ, 2
<
ÙÙ2 3
int
ÙÙ3 6
>
ÙÙ6 7
(
ÙÙ7 8
type
ÙÙ8 <
:
ÙÙ< =
$str
ÙÙ> G
,
ÙÙG H
nullable
ÙÙI Q
:
ÙÙQ R
false
ÙÙS X
)
ÙÙX Y
.
ıı 

Annotation
ıı #
(
ıı# $
$str
ıı$ D
,
ııD E+
NpgsqlValueGenerationStrategy
ııF c
.
ııc d%
IdentityByDefaultColumn
ııd {
)
ıı{ |
,
ıı| }
UserId
ˆˆ 
=
ˆˆ 
table
ˆˆ "
.
ˆˆ" #
Column
ˆˆ# )
<
ˆˆ) *
string
ˆˆ* 0
>
ˆˆ0 1
(
ˆˆ1 2
type
ˆˆ2 6
:
ˆˆ6 7
$str
ˆˆ8 >
,
ˆˆ> ?
nullable
ˆˆ@ H
:
ˆˆH I
false
ˆˆJ O
)
ˆˆO P
,
ˆˆP Q
FriendId
˜˜ 
=
˜˜ 
table
˜˜ $
.
˜˜$ %
Column
˜˜% +
<
˜˜+ ,
string
˜˜, 2
>
˜˜2 3
(
˜˜3 4
type
˜˜4 8
:
˜˜8 9
$str
˜˜: @
,
˜˜@ A
nullable
˜˜B J
:
˜˜J K
false
˜˜L Q
)
˜˜Q R
,
˜˜R S
IsApproving
¯¯ 
=
¯¯  !
table
¯¯" '
.
¯¯' (
Column
¯¯( .
<
¯¯. /
bool
¯¯/ 3
>
¯¯3 4
(
¯¯4 5
type
¯¯5 9
:
¯¯9 :
$str
¯¯; D
,
¯¯D E
nullable
¯¯F N
:
¯¯N O
false
¯¯P U
)
¯¯U V
}
˘˘ 
,
˘˘ 
constraints
˙˙ 
:
˙˙ 
table
˙˙ "
=>
˙˙# %
{
˚˚ 
table
¸¸ 
.
¸¸ 

PrimaryKey
¸¸ $
(
¸¸$ %
$str
¸¸% 8
,
¸¸8 9
x
¸¸: ;
=>
¸¸< >
x
¸¸? @
.
¸¸@ A
FriendRequestId
¸¸A P
)
¸¸P Q
;
¸¸Q R
table
˝˝ 
.
˝˝ 

ForeignKey
˝˝ $
(
˝˝$ %
name
˛˛ 
:
˛˛ 
$str
˛˛ F
,
˛˛F G
column
ˇˇ 
:
ˇˇ 
x
ˇˇ  !
=>
ˇˇ" $
x
ˇˇ% &
.
ˇˇ& '
FriendId
ˇˇ' /
,
ˇˇ/ 0
principalTable
ÄÄ &
:
ÄÄ& '
$str
ÄÄ( 5
,
ÄÄ5 6
principalColumn
ÅÅ '
:
ÅÅ' (
$str
ÅÅ) -
,
ÅÅ- .
onDelete
ÇÇ  
:
ÇÇ  !
ReferentialAction
ÇÇ" 3
.
ÇÇ3 4
Cascade
ÇÇ4 ;
)
ÇÇ; <
;
ÇÇ< =
table
ÉÉ 
.
ÉÉ 

ForeignKey
ÉÉ $
(
ÉÉ$ %
name
ÑÑ 
:
ÑÑ 
$str
ÑÑ D
,
ÑÑD E
column
ÖÖ 
:
ÖÖ 
x
ÖÖ  !
=>
ÖÖ" $
x
ÖÖ% &
.
ÖÖ& '
UserId
ÖÖ' -
,
ÖÖ- .
principalTable
ÜÜ &
:
ÜÜ& '
$str
ÜÜ( 5
,
ÜÜ5 6
principalColumn
áá '
:
áá' (
$str
áá) -
,
áá- .
onDelete
àà  
:
àà  !
ReferentialAction
àà" 3
.
àà3 4
Cascade
àà4 ;
)
àà; <
;
àà< =
}
ââ 
)
ââ 
;
ââ 
migrationBuilder
ãã 
.
ãã 
CreateTable
ãã (
(
ãã( )
name
åå 
:
åå 
$str
åå #
,
åå# $
columns
çç 
:
çç 
table
çç 
=>
çç !
new
çç" %
{
éé 
FriendshipId
èè  
=
èè! "
table
èè# (
.
èè( )
Column
èè) /
<
èè/ 0
int
èè0 3
>
èè3 4
(
èè4 5
type
èè5 9
:
èè9 :
$str
èè; D
,
èèD E
nullable
èèF N
:
èèN O
false
èèP U
)
èèU V
.
êê 

Annotation
êê #
(
êê# $
$str
êê$ D
,
êêD E+
NpgsqlValueGenerationStrategy
êêF c
.
êêc d%
IdentityByDefaultColumn
êêd {
)
êê{ |
,
êê| }
UserId
ëë 
=
ëë 
table
ëë "
.
ëë" #
Column
ëë# )
<
ëë) *
string
ëë* 0
>
ëë0 1
(
ëë1 2
type
ëë2 6
:
ëë6 7
$str
ëë8 >
,
ëë> ?
nullable
ëë@ H
:
ëëH I
false
ëëJ O
)
ëëO P
,
ëëP Q
FriendId
íí 
=
íí 
table
íí $
.
íí$ %
Column
íí% +
<
íí+ ,
string
íí, 2
>
íí2 3
(
íí3 4
type
íí4 8
:
íí8 9
$str
íí: @
,
íí@ A
nullable
ííB J
:
ííJ K
false
ííL Q
)
ííQ R
}
ìì 
,
ìì 
constraints
îî 
:
îî 
table
îî "
=>
îî# %
{
ïï 
table
ññ 
.
ññ 

PrimaryKey
ññ $
(
ññ$ %
$str
ññ% 5
,
ññ5 6
x
ññ7 8
=>
ññ9 ;
x
ññ< =
.
ññ= >
FriendshipId
ññ> J
)
ññJ K
;
ññK L
table
óó 
.
óó 

ForeignKey
óó $
(
óó$ %
name
òò 
:
òò 
$str
òò C
,
òòC D
column
ôô 
:
ôô 
x
ôô  !
=>
ôô" $
x
ôô% &
.
ôô& '
FriendId
ôô' /
,
ôô/ 0
principalTable
öö &
:
öö& '
$str
öö( 5
,
öö5 6
principalColumn
õõ '
:
õõ' (
$str
õõ) -
,
õõ- .
onDelete
úú  
:
úú  !
ReferentialAction
úú" 3
.
úú3 4
Cascade
úú4 ;
)
úú; <
;
úú< =
table
ùù 
.
ùù 

ForeignKey
ùù $
(
ùù$ %
name
ûû 
:
ûû 
$str
ûû A
,
ûûA B
column
üü 
:
üü 
x
üü  !
=>
üü" $
x
üü% &
.
üü& '
UserId
üü' -
,
üü- .
principalTable
†† &
:
††& '
$str
††( 5
,
††5 6
principalColumn
°° '
:
°°' (
$str
°°) -
,
°°- .
onDelete
¢¢  
:
¢¢  !
ReferentialAction
¢¢" 3
.
¢¢3 4
Cascade
¢¢4 ;
)
¢¢; <
;
¢¢< =
}
££ 
)
££ 
;
££ 
migrationBuilder
•• 
.
•• 
CreateTable
•• (
(
••( )
name
¶¶ 
:
¶¶ 
$str
¶¶ 
,
¶¶ 
columns
ßß 
:
ßß 
table
ßß 
=>
ßß !
new
ßß" %
{
®® 
Id
©© 
=
©© 
table
©© 
.
©© 
Column
©© %
<
©©% &
int
©©& )
>
©©) *
(
©©* +
type
©©+ /
:
©©/ 0
$str
©©1 :
,
©©: ;
nullable
©©< D
:
©©D E
false
©©F K
)
©©K L
.
™™ 

Annotation
™™ #
(
™™# $
$str
™™$ D
,
™™D E+
NpgsqlValueGenerationStrategy
™™F c
.
™™c d%
IdentityByDefaultColumn
™™d {
)
™™{ |
,
™™| }
Image
´´ 
=
´´ 
table
´´ !
.
´´! "
Column
´´" (
<
´´( )
byte
´´) -
[
´´- .
]
´´. /
>
´´/ 0
(
´´0 1
type
´´1 5
:
´´5 6
$str
´´7 >
,
´´> ?
nullable
´´@ H
:
´´H I
false
´´J O
)
´´O P
,
´´P Q
UserId
¨¨ 
=
¨¨ 
table
¨¨ "
.
¨¨" #
Column
¨¨# )
<
¨¨) *
string
¨¨* 0
>
¨¨0 1
(
¨¨1 2
type
¨¨2 6
:
¨¨6 7
$str
¨¨8 >
,
¨¨> ?
nullable
¨¨@ H
:
¨¨H I
false
¨¨J O
)
¨¨O P
}
≠≠ 
,
≠≠ 
constraints
ÆÆ 
:
ÆÆ 
table
ÆÆ "
=>
ÆÆ# %
{
ØØ 
table
∞∞ 
.
∞∞ 

PrimaryKey
∞∞ $
(
∞∞$ %
$str
∞∞% 0
,
∞∞0 1
x
∞∞2 3
=>
∞∞4 6
x
∞∞7 8
.
∞∞8 9
Id
∞∞9 ;
)
∞∞; <
;
∞∞< =
table
±± 
.
±± 

ForeignKey
±± $
(
±±$ %
name
≤≤ 
:
≤≤ 
$str
≤≤ <
,
≤≤< =
column
≥≥ 
:
≥≥ 
x
≥≥  !
=>
≥≥" $
x
≥≥% &
.
≥≥& '
UserId
≥≥' -
,
≥≥- .
principalTable
¥¥ &
:
¥¥& '
$str
¥¥( 5
,
¥¥5 6
principalColumn
µµ '
:
µµ' (
$str
µµ) -
,
µµ- .
onDelete
∂∂  
:
∂∂  !
ReferentialAction
∂∂" 3
.
∂∂3 4
Cascade
∂∂4 ;
)
∂∂; <
;
∂∂< =
}
∑∑ 
)
∑∑ 
;
∑∑ 
migrationBuilder
ππ 
.
ππ 
CreateIndex
ππ (
(
ππ( )
name
∫∫ 
:
∫∫ 
$str
∫∫ 2
,
∫∫2 3
table
ªª 
:
ªª 
$str
ªª )
,
ªª) *
column
ºº 
:
ºº 
$str
ºº  
)
ºº  !
;
ºº! "
migrationBuilder
ææ 
.
ææ 
CreateIndex
ææ (
(
ææ( )
name
øø 
:
øø 
$str
øø %
,
øø% &
table
¿¿ 
:
¿¿ 
$str
¿¿ $
,
¿¿$ %
column
¡¡ 
:
¡¡ 
$str
¡¡ (
,
¡¡( )
unique
¬¬ 
:
¬¬ 
true
¬¬ 
)
¬¬ 
;
¬¬ 
migrationBuilder
ƒƒ 
.
ƒƒ 
CreateIndex
ƒƒ (
(
ƒƒ( )
name
≈≈ 
:
≈≈ 
$str
≈≈ 2
,
≈≈2 3
table
∆∆ 
:
∆∆ 
$str
∆∆ )
,
∆∆) *
column
«« 
:
«« 
$str
««  
)
««  !
;
««! "
migrationBuilder
…… 
.
…… 
CreateIndex
…… (
(
……( )
name
   
:
   
$str
   2
,
  2 3
table
ÀÀ 
:
ÀÀ 
$str
ÀÀ )
,
ÀÀ) *
column
ÃÃ 
:
ÃÃ 
$str
ÃÃ  
)
ÃÃ  !
;
ÃÃ! "
migrationBuilder
ŒŒ 
.
ŒŒ 
CreateIndex
ŒŒ (
(
ŒŒ( )
name
œœ 
:
œœ 
$str
œœ 1
,
œœ1 2
table
–– 
:
–– 
$str
–– (
,
––( )
column
—— 
:
—— 
$str
——  
)
——  !
;
——! "
migrationBuilder
”” 
.
”” 
CreateIndex
”” (
(
””( )
name
‘‘ 
:
‘‘ 
$str
‘‘ "
,
‘‘" #
table
’’ 
:
’’ 
$str
’’ $
,
’’$ %
column
÷÷ 
:
÷÷ 
$str
÷÷ )
)
÷÷) *
;
÷÷* +
migrationBuilder
ÿÿ 
.
ÿÿ 
CreateIndex
ÿÿ (
(
ÿÿ( )
name
ŸŸ 
:
ŸŸ 
$str
ŸŸ >
,
ŸŸ> ?
table
⁄⁄ 
:
⁄⁄ 
$str
⁄⁄ $
,
⁄⁄$ %
column
€€ 
:
€€ 
$str
€€ 1
)
€€1 2
;
€€2 3
migrationBuilder
›› 
.
›› 
CreateIndex
›› (
(
››( )
name
ﬁﬁ 
:
ﬁﬁ 
$str
ﬁﬁ %
,
ﬁﬁ% &
table
ﬂﬂ 
:
ﬂﬂ 
$str
ﬂﬂ $
,
ﬂﬂ$ %
column
‡‡ 
:
‡‡ 
$str
‡‡ ,
,
‡‡, -
unique
·· 
:
·· 
true
·· 
)
·· 
;
·· 
migrationBuilder
„„ 
.
„„ 
CreateIndex
„„ (
(
„„( )
name
‰‰ 
:
‰‰ 
$str
‰‰ +
,
‰‰+ ,
table
ÂÂ 
:
ÂÂ 
$str
ÂÂ "
,
ÂÂ" #
column
ÊÊ 
:
ÊÊ 
$str
ÊÊ  
)
ÊÊ  !
;
ÊÊ! "
migrationBuilder
ËË 
.
ËË 
CreateIndex
ËË (
(
ËË( )
name
ÈÈ 
:
ÈÈ 
$str
ÈÈ +
,
ÈÈ+ ,
table
ÍÍ 
:
ÍÍ 
$str
ÍÍ "
,
ÍÍ" #
column
ÎÎ 
:
ÎÎ 
$str
ÎÎ  
)
ÎÎ  !
;
ÎÎ! "
migrationBuilder
ÌÌ 
.
ÌÌ 
CreateIndex
ÌÌ (
(
ÌÌ( )
name
ÓÓ 
:
ÓÓ 
$str
ÓÓ 2
,
ÓÓ2 3
table
ÔÔ 
:
ÔÔ 
$str
ÔÔ '
,
ÔÔ' (
column
 
:
 
$str
 "
)
" #
;
# $
migrationBuilder
ÚÚ 
.
ÚÚ 
CreateIndex
ÚÚ (
(
ÚÚ( )
name
ÛÛ 
:
ÛÛ 
$str
ÛÛ 0
,
ÛÛ0 1
table
ÙÙ 
:
ÙÙ 
$str
ÙÙ '
,
ÙÙ' (
column
ıı 
:
ıı 
$str
ıı  
)
ıı  !
;
ıı! "
migrationBuilder
˜˜ 
.
˜˜ 
CreateIndex
˜˜ (
(
˜˜( )
name
¯¯ 
:
¯¯ 
$str
¯¯ /
,
¯¯/ 0
table
˘˘ 
:
˘˘ 
$str
˘˘ $
,
˘˘$ %
column
˙˙ 
:
˙˙ 
$str
˙˙ "
)
˙˙" #
;
˙˙# $
migrationBuilder
¸¸ 
.
¸¸ 
CreateIndex
¸¸ (
(
¸¸( )
name
˝˝ 
:
˝˝ 
$str
˝˝ -
,
˝˝- .
table
˛˛ 
:
˛˛ 
$str
˛˛ $
,
˛˛$ %
column
ˇˇ 
:
ˇˇ 
$str
ˇˇ  
)
ˇˇ  !
;
ˇˇ! "
migrationBuilder
ÅÅ 
.
ÅÅ 
CreateIndex
ÅÅ (
(
ÅÅ( )
name
ÇÇ 
:
ÇÇ 
$str
ÇÇ (
,
ÇÇ( )
table
ÉÉ 
:
ÉÉ 
$str
ÉÉ 
,
ÉÉ  
column
ÑÑ 
:
ÑÑ 
$str
ÑÑ  
)
ÑÑ  !
;
ÑÑ! "
migrationBuilder
ÜÜ 
.
ÜÜ 
CreateIndex
ÜÜ (
(
ÜÜ( )
name
áá 
:
áá 
$str
áá ;
,
áá; <
table
àà 
:
àà 
$str
àà !
,
àà! "
column
ââ 
:
ââ 
$str
ââ 1
)
ââ1 2
;
ââ2 3
}
ää 	
	protected
çç 
override
çç 
void
çç 
Down
çç  $
(
çç$ %
MigrationBuilder
çç% 5
migrationBuilder
çç6 F
)
ççF G
{
éé 	
migrationBuilder
èè 
.
èè 
	DropTable
èè &
(
èè& '
name
êê 
:
êê 
$str
êê (
)
êê( )
;
êê) *
migrationBuilder
íí 
.
íí 
	DropTable
íí &
(
íí& '
name
ìì 
:
ìì 
$str
ìì (
)
ìì( )
;
ìì) *
migrationBuilder
ïï 
.
ïï 
	DropTable
ïï &
(
ïï& '
name
ññ 
:
ññ 
$str
ññ (
)
ññ( )
;
ññ) *
migrationBuilder
òò 
.
òò 
	DropTable
òò &
(
òò& '
name
ôô 
:
ôô 
$str
ôô '
)
ôô' (
;
ôô( )
migrationBuilder
õõ 
.
õõ 
	DropTable
õõ &
(
õõ& '
name
úú 
:
úú 
$str
úú (
)
úú( )
;
úú) *
migrationBuilder
ûû 
.
ûû 
	DropTable
ûû &
(
ûû& '
name
üü 
:
üü 
$str
üü !
)
üü! "
;
üü" #
migrationBuilder
°° 
.
°° 
	DropTable
°° &
(
°°& '
name
¢¢ 
:
¢¢ 
$str
¢¢ !
)
¢¢! "
;
¢¢" #
migrationBuilder
§§ 
.
§§ 
	DropTable
§§ &
(
§§& '
name
•• 
:
•• 
$str
•• &
)
••& '
;
••' (
migrationBuilder
ßß 
.
ßß 
	DropTable
ßß &
(
ßß& '
name
®® 
:
®® 
$str
®® #
)
®®# $
;
®®$ %
migrationBuilder
™™ 
.
™™ 
	DropTable
™™ &
(
™™& '
name
´´ 
:
´´ 
$str
´´ 
)
´´ 
;
´´  
migrationBuilder
≠≠ 
.
≠≠ 
	DropTable
≠≠ &
(
≠≠& '
name
ÆÆ 
:
ÆÆ 
$str
ÆÆ  
)
ÆÆ  !
;
ÆÆ! "
migrationBuilder
∞∞ 
.
∞∞ 
	DropTable
∞∞ &
(
∞∞& '
name
±± 
:
±± 
$str
±± #
)
±±# $
;
±±$ %
migrationBuilder
≥≥ 
.
≥≥ 
	DropTable
≥≥ &
(
≥≥& '
name
¥¥ 
:
¥¥ 
$str
¥¥ #
)
¥¥# $
;
¥¥$ %
migrationBuilder
∂∂ 
.
∂∂ 
	DropTable
∂∂ &
(
∂∂& '
name
∑∑ 
:
∑∑ 
$str
∑∑ -
)
∑∑- .
;
∑∑. /
}
∏∏ 	
}
ππ 
}∫∫ Û
lC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Domain.Account\Enum\UserRole.cs
	namespace 	
FanPage
 
. 
Domain 
. 
Account  
.  !
Enum! %
{ 
public 

enum 
UserRole 
{ 
None 
= 
$num 
, 
User 
= 
$num 
, 
	Moderator 
= 
$num 
, 
Admin 
= 
$num 
}		 
}

 â
lC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Domain.Account\Entities\User.cs
	namespace 	
FanPage
 
. 
Domain 
. 
Account  
.  !
Entities! )
{ 
public 

class 
User 
: 
IdentityUser $
{ 
public 
byte 
[ 
] 
? 

UserAvatar !
{" #
get$ '
;' (
set) ,
;, -
}. /
public

 
string

 
WhoBan

 
{

 
get

 "
;

" #
set

$ '
;

' (
}

) *
public 
int #
CustomizationSettingsId *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
public !
CustomizationSettings $!
CustomizationSettings% :
{; <
get= @
;@ A
setB E
;E F
}G H
[ 	
InverseProperty	 
( 
$str 
)  
]  !
public" (
ICollection) 4
<4 5

Friendship5 ?
>? @
	MyFriendsA J
{K L
getM P
;P Q
setR U
;U V
}W X
[ 	
InverseProperty	 
( 
$str !
)! "
]" #
public$ *
ICollection+ 6
<6 7

Friendship7 A
>A B
FriendsOfMineC P
{Q R
getS V
;V W
setX [
;[ \
}] ^
public 
ICollection 
< 
Follower #
># $
	Followers% .
{/ 0
get1 4
;4 5
set6 9
;9 :
}; <
public 
ICollection 
< 
Bookmark #
># $
	Bookmarks% .
{/ 0
get1 4
;4 5
set6 9
;9 :
}; <
public 
ICollection 
< 
Photo  
>  !
Photos" (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
[ 	
InverseProperty	 
( 
$str 
)  
]  !
public" (
ICollection) 4
<4 5
FriendRequest5 B
>B C
SentFriendRequestsD V
{W X
getY \
;\ ]
set^ a
;a b
}c d
[ 	
InverseProperty	 
( 
$str !
)! "
]" #
public$ *
ICollection+ 6
<6 7
FriendRequest7 D
>D E"
ReceivedFriendRequestsF \
{] ^
get_ b
;b c
setd g
;g h
}i j
} 
} ø	
oC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Domain.Account\Entities\Sticker.cs
	namespace 	
FanPage
 
. 
Domain 
. 
Account  
.  !
Entities! )
{ 
public 

class 
Sticker 
{ 
[ 	
Key	 
] 
public 
int 
	StickerId "
{# $
get% (
;( )
set* -
;- .
}/ 0
public

 
byte

 
[

 
]

 
Image

 
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
public 
int #
CustomizationSettingsId *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
[ 	

ForeignKey	 
( 
$str -
)- .
]. /
public !
CustomizationSettings $!
CustomizationSettings% :
{; <
get= @
;@ A
setB E
;E F
}G H
} 
} ’
mC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Domain.Account\Entities\Photo.cs
	namespace 	
FanPage
 
. 
Domain 
. 
Account  
.  !
Entities! )
{ 
public 

class 
Photo 
{ 
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
public 
byte 
[ 
] 
Image 
{ 
get !
;! "
set# &
;& '
}( )
public		 
string		 
UserId		 
{		 
get		 "
;		" #
set		$ '
;		' (
}		) *
[ 	

ForeignKey	 
( 
$str 
) 
] 
public %
User& *
User+ /
{0 1
get2 5
;5 6
set7 :
;: ;
}< =
} 
} —
{C:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Domain.Account\Entities\IdentityUserManager.cs
	namespace 	
FanPage
 
. 
Domain 
. 
Account  
.  !
Entities! )
{ 
public 

class 
IdentityUserManager $
:% &
UserManager' 2
<2 3
User3 7
>7 8
{ 
public		 
IdentityUserManager		 "
(		" #

IUserStore		# -
<		- .
User		. 2
>		2 3
store		4 9
,		9 :
IOptions		; C
<		C D
IdentityOptions		D S
>		S T
optionsAccessor		U d
,		d e
IPasswordHasher

 
<

 
User

  
>

  !
passwordHasher

" 0
,

0 1
IEnumerable 
< 
IUserValidator &
<& '
User' +
>+ ,
>, -
userValidators. <
,< =
IEnumerable> I
<I J
IPasswordValidatorJ \
<\ ]
User] a
>a b
>b c
passwordValidatorsd v
,v w
ILookupNormalizer 
keyNormalizer +
,+ ,"
IdentityErrorDescriber- C
errorsD J
,J K
IServiceProviderL \
services] e
,e f
ILogger 
< 
UserManager 
<  
User  $
>$ %
>% &
logger' -
)- .
: 
base 
( 
store 
, 
optionsAccessor )
,) *
passwordHasher+ 9
,9 :
userValidators; I
,I J
passwordValidatorsK ]
,] ^
keyNormalizer_ l
,l m
errorsn t
,t u
services 
, 
logger  
)  !
{ 	
Options 
. 
User 
. %
AllowedUserNameCharacters 2
=3 4
null5 9
;9 :
Options 
. 
SignIn 
. !
RequireConfirmedEmail 0
=1 2
false3 8
;8 9
} 	
} 
} ˝

rC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Domain.Account\Entities\Friendship.cs
	namespace 	
FanPage
 
. 
Domain 
. 
Account  
.  !
Entities! )
{ 
public 

class 

Friendship 
{ 
[ 	
Key	 
] 
public 
int 
FriendshipId %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public

 
string

 
UserId

 
{

 
get

 "
;

" #
set

$ '
;

' (
}

) *
[ 	

ForeignKey	 
( 
$str 
) 
] 
public %
User& *
User+ /
{0 1
get2 5
;5 6
set7 :
;: ;
}< =
public 
string 
FriendId 
{  
get! $
;$ %
set& )
;) *
}+ ,
[ 	

ForeignKey	 
( 
$str 
) 
]  
public! '
User( ,
Friend- 3
{4 5
get6 9
;9 :
set; >
;> ?
}@ A
} 
} í
uC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Domain.Account\Entities\FriendRequest.cs
	namespace 	
FanPage
 
. 
Domain 
. 
Account  
.  !
Entities! )
;) *
public 
class 
FriendRequest 
{ 
[ 
Key 
] 	
public		 

int		 
FriendRequestId		 
{		  
get		! $
;		$ %
set		& )
;		) *
}		+ ,
public 

string 
UserId 
{ 
get 
; 
set  #
;# $
}% &
[ 

ForeignKey 
( 
$str 
) 
] 
public 

User 
User 
{ 
get 
; 
set 
;  
}! "
public 

string 
FriendId 
{ 
get  
;  !
set" %
;% &
}' (
[ 

ForeignKey 
( 
$str 
) 
] 
public 

User 
Friend 
{ 
get 
; 
set !
;! "
}# $
public 

bool 
IsApproving 
{ 
get !
;! "
set# &
;& '
}( )
} ï
pC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Domain.Account\Entities\Follower.cs
	namespace 	
FanPage
 
. 
Domain 
. 
Account  
.  !
Entities! )
{ 
public 

class 
Follower 
{ 
[ 	
Key	 
] 
public 
int 

FollowerId #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public		 
string		 
?		 
UserId		 
{		 
get		  #
;		# $
set		% (
;		( )
}		* +
public

 
User

 
?

 
User

 
{

 
get

 
;

  
set

! $
;

$ %
}

& '
} 
} í
}C:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Domain.Account\Entities\CustomizationSettings.cs
	namespace 	
FanPage
 
. 
Domain 
. 
Account  
.  !
Entities! )
{ 
public 

class !
CustomizationSettings &
{ 
[ 	
Key	 
] 
public 
int #
CustomizationSettingsId 0
{1 2
get3 6
;6 7
set8 ;
;; <
}= >
public		 
ICollection		 
<		 
Sticker		 "
>		" #
CustomStickers		$ 2
{		3 4
get		5 8
;		8 9
set		: =
;		= >
}		? @
public 
byte 
[ 
] 
? 
BannerImage "
{# $
get% (
;( )
set* -
;- .
}/ 0
} 
} ø	
pC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Domain.Account\Entities\Bookmark.cs
	namespace 	
FanPage
 
. 
Domain 
. 
Account  
.  !
Entities! )
{ 
public 

class 
Bookmark 
{ 
[ 	
Key	 
] 
public 
int 

BookmarkId #
{$ %
get& )
;) *
set+ .
;. /
}0 1
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
public		 
string		 
UserId		 
{		 
get		 "
;		" #
set		$ '
;		' (
}		) *
public

 
User

 
User

 
{

 
get

 
;

 
set

  #
;

# $
}

% &
public 
int 
FanficReadingId "
{# $
get% (
;( )
set* -
;- .
}/ 0
} 
} ˙
rC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Domain.Account\Context\UserContext.cs
	namespace 	
FanPage
 
. 
Domain 
. 
Account  
.  !
Context! (
{ 
public 

class 
UserContext 
: 
IdentityDbContext 0
<0 1
Entities1 9
.9 :
User: >
>> ?
{ 
public		 
DbSet		 
<		 
Bookmark		 
>		 
	Bookmarks		 (
{		) *
get		+ .
;		. /
set		0 3
;		3 4
}		5 6
public 
DbSet 
< !
CustomizationSettings *
>* +!
CustomizationSettings, A
{B C
getD G
;G H
setI L
;L M
}N O
public 
DbSet 
< 
Follower 
> 
	Followers (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
DbSet 
< 
FriendRequest "
>" #
FriendRequests$ 2
{3 4
get5 8
;8 9
set: =
;= >
}? @
public 
DbSet 
< 

Friendship 
>  
Friendships! ,
{- .
get/ 2
;2 3
set4 7
;7 8
}9 :
public 
DbSet 
< 
Sticker 
> 
Stickers &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
DbSet 
< 
Photo 
> 
Photos "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
UserContext 
( 
DbContextOptions +
<+ ,
UserContext, 7
>7 8
options9 @
)@ A
:B C
base 
( 
options 
) 
{ 	
} 	
} 
} 