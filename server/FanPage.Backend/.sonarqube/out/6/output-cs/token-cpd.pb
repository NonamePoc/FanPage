â
vC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Common\Models\PasswordValidateResponse.cs
	namespace 	
FanPage
 
. 
Common 
. 
Models 
{ 
public		 

class		 $
PasswordValidateResponse		 )
{

 
public $
PasswordValidateResponse '
(' (
)( )
{ 	
Errors 
= 
new 

Dictionary #
<# $
string$ *
,* +
string, 2
>2 3
(3 4
)4 5
;5 6
} 	
public 
IDictionary 
< 
string !
,! "
string# )
>) *
Errors+ 1
{2 3
get4 7
;7 8
set9 <
;< =
}> ?
public 
bool 
	Succeeded 
=>  
!! "
Errors" (
.( )
Any) ,
(, -
)- .
;. /
} 
} á
rC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Common\Interfaces\IPasswordManager.cs
	namespace 	
FanPage
 
. 
Common 
. 

Interfaces #
{ 
public 

	interface 
IPasswordManager %
{ 
string 
GetNewPassword 
( 
) 
;  $
PasswordValidateResponse		  
ValidatePassword		! 1
(		1 2
string		2 8
password		9 A
)		A B
;		B C
}

 
} ê
rC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Common\Interfaces\IJwtTokenManager.cs
	namespace 	
FanPage
 
. 
Common 
. 

Interfaces #
{ 
public 

	interface 
IJwtTokenManager %
{ 
string		 
GetTokenFromHeader		 !
(		! "
HttpRequest		" -
request		. 5
)		5 6
;		6 7
Task 
< 
bool 
> 
IsTokenExists  
(  !
HttpRequest! ,
request- 4
)4 5
;5 6
Task 
< 
string 
> 
GenerateToken "
(" #
IdentityUser# /
user0 4
)4 5
;5 6
string 
RefreshToken 
( 
string "
token# (
,( )
string* 0
email1 6
,6 7
string8 >
userId? E
)E F
;F G
string 
GetUserIdFromToken !
(! "
HttpRequest" -
request. 5
)5 6
;6 7
string  
GetUserNameFromToken #
(# $
HttpRequest$ /
request0 7
)7 8
;8 9
Task 
< 
string 
> 
GoogleLogin  
(  !
string! '
googleToken( 3
)3 4
;4 5
Task 
< 
string 
> "
DecodeTokenAndGetEmail +
(+ ,
string, 2
token3 8
)8 9
;9 :
} 
} É
oC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Common\Interfaces\IJwtGenerator.cs
	namespace 	
FanPage
 
. 
Common 
. 

Interfaces #
{ 
public 

	interface 
IJwtGenerator "
{ 
Task 
< 
string 
> 
CreateToken  
(  !
IdentityUser! -
user. 2
)2 3
;3 4
string		 
RefreshToken		 
(		 
string		 "
token		# (
,		( )
string		* 0
email		1 6
,		6 7
string		8 >
userId		? E
)		E F
;		F G
Task 
< 
string 
> !
CreateTokenFromGoogle *
(* +
string+ 1
googleToken2 =
)= >
;> ?
} 
} ¼I
{C:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Common\Implementations\UserPasswordSettings.cs
	namespace 	
FanPage
 
. 
Common 
. 
Implementations (
{ 
public 

class  
UserPasswordSettings %
:& '
IPasswordSettings( 9
{ 
private 
const 
string 
LowercaseCharacters 0
=1 2
$str3 O
;O P
private		 
const		 
string		 
UppercaseCharacters		 0
=		1 2
$str		3 O
;		O P
private

 
const

 
string

 
NumericCharacters

 .
=

/ 0
$str

1 =
;

= >
private 
const 
string $
DefaultSpecialCharacters 5
=6 7
$str8 B
;B C
private 
const 
int $
DefaultMinPasswordLength 2
=3 4
$num5 6
;6 7
private 
const 
int $
DefaultMaxPasswordLength 2
=3 4
$num5 7
;7 8
public  
UserPasswordSettings #
(# $
bool$ (
includeLowercase) 9
,9 :
bool; ?
includeUppercase@ P
,P Q
boolR V
includeNumericW e
,e f
bool 
includeSpecial 
,  
int 
passwordLength 
, 
int  #
maximumAttempts$ 3
,3 4
bool5 9
usingDefaults: G
)G H
{ 	
IncludeLowercase 
= 
includeLowercase /
;/ 0
IncludeUppercase 
= 
includeUppercase /
;/ 0
IncludeNumeric 
= 
includeNumeric +
;+ ,
IncludeSpecial 
= 
includeSpecial +
;+ ,
PasswordLength 
= 
passwordLength +
;+ ,
MaximumAttempts 
= 
maximumAttempts -
;- .
MinimumLength 
= $
DefaultMinPasswordLength 4
;4 5
MaximumLength 
= $
DefaultMaxPasswordLength 4
;4 5
UsingDefaults 
= 
usingDefaults )
;) *
SpecialCharacters 
= $
DefaultSpecialCharacters  8
;8 9
CharacterSet 
= 
BuildCharacterSet ,
(, -
includeLowercase- =
,= >
includeUppercase? O
,O P
includeNumericQ _
,_ `
includeSpeciala o
)o p
;p q
} 	
private   
bool   
UsingDefaults   "
{  # $
get  % (
;  ( )
set  * -
;  - .
}  / 0
public!! 
string!! 
SpecialCharacters!! '
{!!( )
get!!* -
;!!- .
set!!/ 2
;!!2 3
}!!4 5
public## 
bool## 
IncludeLowercase## $
{##% &
get##' *
;##* +
private##, 3
set##4 7
;##7 8
}##9 :
public$$ 
bool$$ 
IncludeUppercase$$ $
{$$% &
get$$' *
;$$* +
private$$, 3
set$$4 7
;$$7 8
}$$9 :
public%% 
bool%% 
IncludeNumeric%% "
{%%# $
get%%% (
;%%( )
private%%* 1
set%%2 5
;%%5 6
}%%7 8
public&& 
bool&& 
IncludeSpecial&& "
{&&# $
get&&% (
;&&( )
private&&* 1
set&&2 5
;&&5 6
}&&7 8
public'' 
int'' 
PasswordLength'' !
{''" #
get''$ '
;''' (
set'') ,
;'', -
}''. /
public(( 
string(( 
CharacterSet(( "
{((# $
get((% (
;((( )
private((* 1
set((2 5
;((5 6
}((7 8
public)) 
int)) 
MaximumAttempts)) "
{))# $
get))% (
;))( )
}))* +
public** 
int** 
MinimumLength**  
{**! "
get**# &
;**& '
}**( )
public++ 
int++ 
MaximumLength++  
{++! "
get++# &
;++& '
}++( )
public-- 
IPasswordSettings--  
AddLowercase--! -
(--- .
)--. /
{.. 	
StopUsingDefaults// 
(// 
)// 
;//  
IncludeLowercase00 
=00 
true00 #
;00# $
CharacterSet11 
+=11 
LowercaseCharacters11 /
;11/ 0
return22 
this22 
;22 
}33 	
public55 
IPasswordSettings55  
AddUppercase55! -
(55- .
)55. /
{66 	
StopUsingDefaults77 
(77 
)77 
;77  
IncludeUppercase88 
=88 
true88 #
;88# $
CharacterSet99 
+=99 
UppercaseCharacters99 /
;99/ 0
return:: 
this:: 
;:: 
};; 	
public== 
IPasswordSettings==  

AddNumeric==! +
(==+ ,
)==, -
{>> 	
StopUsingDefaults?? 
(?? 
)?? 
;??  
IncludeNumeric@@ 
=@@ 
true@@ !
;@@! "
CharacterSetAA 
+=AA 
NumericCharactersAA -
;AA- .
returnBB 
thisBB 
;BB 
}CC 	
publicEE 
IPasswordSettingsEE  

AddSpecialEE! +
(EE+ ,
)EE, -
{FF 	
StopUsingDefaultsGG 
(GG 
)GG 
;GG  
IncludeSpecialHH 
=HH 
trueHH !
;HH! "
SpecialCharactersII 
=II $
DefaultSpecialCharactersII  8
;II8 9
CharacterSetJJ 
+=JJ 
SpecialCharactersJJ -
;JJ- .
returnKK 
thisKK 
;KK 
}LL 	
publicNN 
IPasswordSettingsNN  

AddSpecialNN! +
(NN+ ,
stringNN, 2"
specialCharactersToAddNN3 I
)NNI J
{OO 	
StopUsingDefaultsPP 
(PP 
)PP 
;PP  
IncludeSpecialQQ 
=QQ 
trueQQ !
;QQ! "
SpecialCharactersRR 
=RR "
specialCharactersToAddRR  6
;RR6 7
CharacterSetSS 
+=SS "
specialCharactersToAddSS 2
;SS2 3
returnTT 
thisTT 
;TT 
}UU 	
privateWW 
stringWW 
BuildCharacterSetWW (
(WW( )
boolWW) -
includeLowercaseWW. >
,WW> ?
boolWW@ D
includeUppercaseWWE U
,WWU V
boolWWW [
includeNumericWW\ j
,WWj k
boolXX 
includeSpecialXX 
)XX  
{YY 	
varZZ 
characterSetZZ 
=ZZ 
newZZ "
StringBuilderZZ# 0
(ZZ0 1
)ZZ1 2
;ZZ2 3
if[[ 
([[ 
includeLowercase[[  
)[[  !
characterSet[[" .
.[[. /
Append[[/ 5
([[5 6
LowercaseCharacters[[6 I
)[[I J
;[[J K
if]] 
(]] 
includeUppercase]]  
)]]  !
characterSet]]" .
.]]. /
Append]]/ 5
(]]5 6
UppercaseCharacters]]6 I
)]]I J
;]]J K
if__ 
(__ 
includeNumeric__ 
)__ 
characterSet__  ,
.__, -
Append__- 3
(__3 4
NumericCharacters__4 E
)__E F
;__F G
ifaa 
(aa 
includeSpecialaa 
)aa 
characterSetaa  ,
.aa, -
Appendaa- 3
(aa3 4
SpecialCharactersaa4 E
)aaE F
;aaF G
returnbb 
characterSetbb 
.bb  
ToStringbb  (
(bb( )
)bb) *
;bb* +
}cc 	
privateee 
voidee 
StopUsingDefaultsee &
(ee& '
)ee' (
{ff 	
ifgg 
(gg 
!gg 
UsingDefaultsgg 
)gg 
returnhh 
;hh 
CharacterSetjj 
=jj 
stringjj !
.jj! "
Emptyjj" '
;jj' (
IncludeLowercasekk 
=kk 
falsekk $
;kk$ %
IncludeUppercasell 
=ll 
falsell $
;ll$ %
IncludeNumericmm 
=mm 
falsemm "
;mm" #
IncludeSpecialnn 
=nn 
falsenn "
;nn" #
UsingDefaultsoo 
=oo 
falseoo !
;oo! "
}pp 	
}qq 
}rr Ñ&
vC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Common\Implementations\PasswordManager.cs
	namespace 	
FanPage
 
. 
Common 
. 
Implementations (
{ 
public 

class 
PasswordManager  
:! "
IPasswordManager# 3
{ 
private		 
readonly		 
Password		 !
	_password		" +
;		+ ,
private

 
readonly

 
IPasswordSettings

 *
_passwordSettings

+ <
;

< =
public 
PasswordManager 
( 
IPasswordSettings 0
passwordSettings1 A
)A B
{ 	
_passwordSettings 
= 
passwordSettings  0
;0 1
	_password 
= 
new 
Password $
($ %
passwordSettings% 5
)5 6
;6 7
} 	
public 
string 
GetNewPassword $
($ %
)% &
{ 	
return 
	_password 
. 
Next !
(! "
)" #
;# $
} 	
public $
PasswordValidateResponse '
ValidatePassword( 8
(8 9
string9 ?
password@ H
)H I
{ 	
var 
errorMessages 
= 
new  #

Dictionary$ .
<. /
string/ 5
,5 6
string7 =
>= >
(> ?
)? @
;@ A
if 
( 
_passwordSettings !
.! "
MinimumLength" /
>0 1
password2 :
.: ;
Length; A
)A B
errorMessages 
. 
Add !
(! "
$str" 1
,1 2
$"3 5
$str5 K
{K L
_passwordSettingsL ]
.] ^
MinimumLength^ k
}k l
"l m
)m n
;n o
if 
( 
_passwordSettings !
.! "
MaximumLength" /
<0 1
password2 :
.: ;
Length; A
)A B
errorMessages 
. 
Add !
(! "
$str" 1
,1 2
$"3 5
$str5 K
{K L
_passwordSettingsL ]
.] ^
MaximumLength^ k
}k l
"l m
)m n
;n o
if!! 
(!! 
_passwordSettings!! !
.!!! "
IncludeLowercase!!" 2
&&!!3 5
!!!6 7
password!!7 ?
.!!? @
Any!!@ C
(!!C D
c!!D E
=>!!F H
char!!I M
.!!M N
IsLower!!N U
(!!U V
c!!V W
)!!W X
)!!X Y
)!!Y Z
errorMessages"" 
."" 
Add"" !
(""! "
$str""" 4
,""4 5
$str""6 d
)""d e
;""e f
if$$ 
($$ 
_passwordSettings$$ !
.$$! "
IncludeUppercase$$" 2
&&$$3 5
!$$6 7
password$$7 ?
.$$? @
Any$$@ C
($$C D
c$$D E
=>$$F H
char$$I M
.$$M N
IsUpper$$N U
($$U V
c$$V W
)$$W X
)$$X Y
)$$Y Z
errorMessages%% 
.%% 
Add%% !
(%%! "
$str%%" 4
,%%4 5
$str%%6 e
)%%e f
;%%f g
if'' 
('' 
_passwordSettings'' !
.''! "
IncludeNumeric''" 0
&&''1 3
!''4 5
password''5 =
.''= >
Any''> A
(''A B
c''B C
=>''D F
char''G K
.''K L
IsDigit''L S
(''S T
c''T U
)''U V
)''V W
)''W X
errorMessages(( 
.(( 
Add(( !
(((! "
$str((" 2
,((2 3
$str((4 W
)((W X
;((X Y
if++ 
(++ 
_passwordSettings++ !
.++! "
IncludeSpecial++" 0
&&++1 3
password++4 <
.++< =
All++= @
(++@ A
char++A E
.++E F
IsLetterOrDigit++F U
)++U V
)++V W
errorMessages,, 
.,, 
Add,, !
(,,! "
$str,," 2
,,,2 3
$str,,4 p
),,p q
;,,q r
var.. 
retval.. 
=.. 
new.. $
PasswordValidateResponse.. 5
{// 
Errors00 
=00 
errorMessages00 &
}11 
;11 
return33 
retval33 
;33 
}44 	
}55 
}66 ó2
vC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Common\Implementations\JwtTokenManager.cs
	namespace 	
FanPage
 
. 
Common 
. 
Implementations (
{ 
public		 

class		 
JwtTokenManager		  
:		! "
IJwtTokenManager		# 3
{

 
private 
readonly 
IJwtGenerator &
_jwtGenerator' 4
;4 5
private 
readonly #
JwtSecurityTokenHandler 0
_tokenHandler1 >
;> ?
public 
JwtTokenManager 
( 
IJwtGenerator ,
jwtGenerator- 9
,9 :#
JwtSecurityTokenHandler #
tokenHandler$ 0
)0 1
{ 	
_jwtGenerator 
= 
jwtGenerator (
;( )
_tokenHandler 
= 
tokenHandler (
;( )
} 	
public 
Task 
< 
bool 
> 
IsTokenExists '
(' (
HttpRequest( 3
request4 ;
); <
{ 	
var 
token 
= 
GetTokenFromHeader *
(* +
request+ 2
)2 3
;3 4
return 
Task 
. 

FromResult "
(" #
token# (
!=) +
null, 0
)0 1
;1 2
} 	
public 
string 
? 
GetTokenFromHeader )
() *
HttpRequest* 5
request6 =
)= >
{ 	
return 
request 
. 
Headers "
." #
TryGetValue# .
(. /
$str/ >
,> ?
out@ C
varD G
authorizationHeaderH [
)[ \
? 
authorizationHeader %
.% &
Single& ,
(, -
)- .
.. /
Split/ 4
(4 5
$str5 8
)8 9
.9 :
Last: >
(> ?
)? @
:   
null   
;   
}!! 	
public## 
async## 
Task## 
<## 
string##  
>##  !
GenerateToken##" /
(##/ 0
IdentityUser##0 <
user##= A
)##A B
{$$ 	
return%% 
await%% 
_jwtGenerator%% &
.%%& '
CreateToken%%' 2
(%%2 3
user%%3 7
)%%7 8
;%%8 9
}&& 	
public(( 
string(( 
RefreshToken(( "
(((" #
string((# )
token((* /
,((/ 0
string((1 7
email((8 =
,((= >
string((? E
userId((F L
)((L M
{)) 	
return** 
_jwtGenerator**  
.**  !
RefreshToken**! -
(**- .
token**. 3
,**3 4
email**5 :
,**: ;
userId**< B
)**B C
;**C D
}++ 	
public-- 
string-- 
GetUserIdFromToken-- (
(--( )
HttpRequest--) 4
request--5 <
)--< =
{.. 	
var// 
token// 
=// 
GetTokenFromHeader// *
(//* +
request//+ 2
)//2 3
;//3 4
var11 
jwtToken11 
=11 
_tokenHandler11 (
.11( )
ReadJwtToken11) 5
(115 6
token116 ;
)11; <
;11< =
var22 
claim22 
=22 
jwtToken22  
.22  !
Claims22! '
.22' (
SingleOrDefault22( 7
(227 8
w228 9
=>22: <
w22= >
.22> ?
Type22? C
==22D F#
JwtRegisteredClaimNames22G ^
.22^ _
Sub22_ b
)22b c
;22c d
return44 
claim44 
?44 
.44 
Value44 
;44  
}55 	
public77 
string77  
GetUserNameFromToken77 *
(77* +
HttpRequest77+ 6
request777 >
)77> ?
{88 	
var99 
token99 
=99 
GetTokenFromHeader99 *
(99* +
request99+ 2
)992 3
;993 4
var;; 
jwtToken;; 
=;; 
_tokenHandler;; (
.;;( )
ReadJwtToken;;) 5
(;;5 6
token;;6 ;
);;; <
;;;< =
var<< 
claim<< 
=<< 
jwtToken<<  
.<<  !
Claims<<! '
.<<' (
SingleOrDefault<<( 7
(<<7 8
w<<8 9
=><<: <
w<<= >
.<<> ?
Type<<? C
==<<D F#
JwtRegisteredClaimNames<<G ^
.<<^ _
Name<<_ c
)<<c d
;<<d e
return>> 
claim>> 
?>> 
.>> 
Value>> 
;>>  
}?? 	
publicAA 
asyncAA 
TaskAA 
<AA 
stringAA  
>AA  !
GoogleLoginAA" -
(AA- .
stringAA. 4
googleTokenAA5 @
)AA@ A
{BB 	
returnCC 
awaitCC 
_jwtGeneratorCC &
.CC& '!
CreateTokenFromGoogleCC' <
(CC< =
googleTokenCC= H
)CCH I
;CCI J
}DD 	
publicFF 
asyncFF 
TaskFF 
<FF 
stringFF  
>FF  !"
DecodeTokenAndGetEmailFF" 8
(FF8 9
stringFF9 ?
tokenFF@ E
)FFE F
{GG 	
varHH 
jwtTokenHH 
=HH 
_tokenHandlerHH (
.HH( )
ReadJwtTokenHH) 5
(HH5 6
tokenHH6 ;
)HH; <
;HH< =
varII 
claimII 
=II 
jwtTokenII  
.II  !
ClaimsII! '
.II' (
SingleOrDefaultII( 7
(II7 8
wII8 9
=>II: <
wII= >
.II> ?
TypeII? C
==IID F#
JwtRegisteredClaimNamesIIG ^
.II^ _
EmailII_ d
)IId e
;IIe f
returnKK 
claimKK 
?KK 
.KK 
ValueKK 
;KK  
}LL 	
}MM 
}NN ÇO
sC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Common\Implementations\JwtGenerator.cs
	namespace 	
FanPage
 
. 
Common 
. 
Implementations (
{ 
public 

class 
JwtGenerator 
: 
IJwtGenerator  -
{ 
private 
readonly 
SigningCredentials +
_credentials, 8
;8 9
private 
readonly 
JwtConfiguration )
_jwtConfiguration* ;
;; <
private 
readonly #
JwtSecurityTokenHandler 0
_tokenHandler1 >
;> ?
private 
readonly 
UserManager $
<$ %
User% )
>) *
_userManager+ 7
;7 8
private 
readonly 
RoleManager $
<$ %
IdentityRole% 1
>1 2
_roleManager3 ?
;? @
public 
JwtGenerator 
( 
JwtConfiguration ,
options- 4
,4 5#
JwtSecurityTokenHandler6 M
tokenHandlerN Z
,Z [
UserManager 
< 
User 
> 
userManager )
,) *
RoleManager+ 6
<6 7
IdentityRole7 C
>C D
roleManagerE P
)P Q
{ 	
_jwtConfiguration 
= 
options  '
;' (
_tokenHandler 
= 
tokenHandler (
;( )
_userManager 
= 
userManager &
;& '
_roleManager 
= 
roleManager &
;& '
var 
securityKey 
= 
new ! 
SymmetricSecurityKey" 6
(6 7
Encoding7 ?
.? @
UTF8@ D
.D E
GetBytesE M
(M N
_jwtConfigurationN _
._ `
Key` c
)c d
)d e
;e f
_credentials   
=   
new   
SigningCredentials   1
(  1 2
securityKey  2 =
,  = >
SecurityAlgorithms  ? Q
.  Q R
HmacSha512Signature  R e
)  e f
;  f g
}!! 	
public$$ 
async$$ 
Task$$ 
<$$ 
string$$  
>$$  !
CreateToken$$" -
($$- .
IdentityUser$$. :
user$$; ?
)$$? @
{%% 	
var&& 
claims&& 
=&& 
await&& 
GetValidClaim&& ,
(&&, -
user&&- 1
)&&1 2
;&&2 3
var'' 
tokenDescriptor'' 
=''  !
new''" %#
SecurityTokenDescriptor''& =
{(( 
Subject)) 
=)) 
new)) 
ClaimsIdentity)) ,
()), -
claims))- 3
)))3 4
,))4 5
Expires** 
=** 
DateTime** "
.**" #
UtcNow**# )
.**) *
Add*** -
(**- .
_jwtConfiguration**. ?
.**? @
LifeTime**@ H
)**H I
,**I J
SigningCredentials++ "
=++# $
_credentials++% 1
},, 
;,, 
var.. 
token.. 
=.. 
_tokenHandler.. %
...% &
CreateToken..& 1
(..1 2
tokenDescriptor..2 A
)..A B
;..B C
return// 
_tokenHandler//  
.//  !

WriteToken//! +
(//+ ,
token//, 1
)//1 2
;//2 3
}00 	
private22 
async22 
Task22 
<22 
List22 
<22  
Claim22  %
>22% &
>22& '
GetValidClaim22( 5
(225 6
IdentityUser226 B
user22C G
)22G H
{33 	
var44 
claims44 
=44 
new44 
List44 !
<44! "
Claim44" '
>44' (
{55 
new66 
Claim66 
(66 #
JwtRegisteredClaimNames66 1
.661 2
Email662 7
,667 8
user669 =
.66= >
Email66> C
)66C D
,66D E
new77 
Claim77 
(77 #
JwtRegisteredClaimNames77 1
.771 2
Sub772 5
,775 6
user777 ;
.77; <
Id77< >
)77> ?
,77? @
new88 
Claim88 
(88 #
JwtRegisteredClaimNames88 1
.881 2
Name882 6
,886 7
user888 <
.88< =
UserName88= E
)88E F
}99 
;99 
var:: 
	userClaim:: 
=:: 
await:: !
_userManager::" .
.::. /
GetClaimsAsync::/ =
(::= >
(::> ?
User::? C
)::C D
user::D H
)::H I
;::I J
claims;; 
.;; 
AddRange;; 
(;; 
	userClaim;; %
);;% &
;;;& '
var<< 
	userRoles<< 
=<< 
_userManager<< (
.<<( )
GetRolesAsync<<) 6
(<<6 7
(<<7 8
User<<8 <
)<<< =
user<<= A
)<<A B
;<<B C
foreach== 
(== 
var== 
userRole== !
in==" $
await==% *
	userRoles==+ 4
)==4 5
{>> 
claims?? 
.?? 
Add?? 
(?? 
new?? 
Claim?? $
(??$ %

ClaimTypes??% /
.??/ 0
Role??0 4
,??4 5
userRole??6 >
)??> ?
)??? @
;??@ A
var@@ 
role@@ 
=@@ 
await@@  
_roleManager@@! -
.@@- .
FindByIdAsync@@. ;
(@@; <
userRole@@< D
)@@D E
;@@E F
ifAA 
(AA 
roleAA 
!=AA 
nullAA  
)AA  !
{BB 
varCC 

roleClaimsCC "
=CC# $
awaitCC% *
_roleManagerCC+ 7
.CC7 8
GetClaimsAsyncCC8 F
(CCF G
roleCCG K
)CCK L
;CCL M
foreachDD 
(DD 
varDD  
	roleClaimDD! *
inDD+ -

roleClaimsDD. 8
)DD8 9
{EE 
claimsFF 
.FF 
AddFF "
(FF" #
	roleClaimFF# ,
)FF, -
;FF- .
}GG 
}HH 
}II 
returnKK 
claimsKK 
;KK 
}LL 	
publicNN 
stringNN 
RefreshTokenNN "
(NN" #
stringNN# )
tokenNN* /
,NN/ 0
stringNN1 7
emailNN8 =
,NN= >
stringNN? E
userIdNNF L
)NNL M
{OO 	
ifPP 
(PP 
!PP 
_tokenHandlerPP 
.PP 
CanReadTokenPP +
(PP+ ,
tokenPP, 1
)PP1 2
)PP2 3
throwQQ 
newQQ ,
 SecurityTokenValidationExceptionQQ :
(QQ: ;
)QQ; <
;QQ< =
varSS 
claimsSS 
=SS 
newSS 
[SS 
]SS 
{TT 
newUU 
ClaimUU 
(UU #
JwtRegisteredClaimNamesUU 1
.UU1 2
EmailUU2 7
,UU7 8
emailUU9 >
)UU> ?
,UU? @
newVV 
ClaimVV 
(VV #
JwtRegisteredClaimNamesVV 1
.VV1 2
SubVV2 5
,VV5 6
userIdVV7 =
)VV= >
}WW 
;WW 
varYY 
tokenDescriptorYY 
=YY  !
newYY" %#
SecurityTokenDescriptorYY& =
{ZZ 
Subject[[ 
=[[ 
new[[ 
ClaimsIdentity[[ ,
([[, -
claims[[- 3
)[[3 4
,[[4 5
Expires\\ 
=\\ 
DateTime\\ "
.\\" #
UtcNow\\# )
.\\) *
Add\\* -
(\\- .
_jwtConfiguration\\. ?
.\\? @
LifeTime\\@ H
)\\H I
,\\I J
SigningCredentials]] "
=]]# $
_credentials]]% 1
}^^ 
;^^ 
var`` 
newToken`` 
=`` 
_tokenHandler`` (
.``( )
CreateToken``) 4
(``4 5
tokenDescriptor``5 D
)``D E
;``E F
returnaa 
_tokenHandleraa  
.aa  !

WriteTokenaa! +
(aa+ ,
newTokenaa, 4
)aa4 5
;aa5 6
}bb 	
publicdd 
asyncdd 
Taskdd 
<dd 
stringdd  
>dd  !!
CreateTokenFromGoogledd" 7
(dd7 8
stringdd8 >
googleTokendd? J
)ddJ K
{ee 	
varff 
payloadff 
=ff 
awaitff "
GoogleJsonWebSignatureff  6
.ff6 7
ValidateAsyncff7 D
(ffD E
googleTokenffE P
)ffP Q
;ffQ R
vargg 
emailgg 
=gg 
payloadgg 
.gg  
Emailgg  %
;gg% &
varhh 
userIdhh 
=hh 
payloadhh  
.hh  !
Subjecthh! (
;hh( )
varii 
userNameii 
=ii 
payloadii "
.ii" #
Nameii# '
;ii' (
varkk 
userkk 
=kk 
newkk 
Userkk 
{ll 
Emailmm 
=mm 
emailmm 
,mm 
UserNamenn 
=nn 
userNamenn #
,nn# $
Idoo 
=oo 
userIdoo 
}pp 
;pp 
returnss 
awaitss 
CreateTokenss $
(ss$ %
userss% )
)ss) *
;ss* +
}tt 	
}uu 
}vv ½	
zC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Common\Configurations\LoggingConfiguration.cs
	namespace 	
FanPage
 
. 
Common 
. 
Configurations '
{ 
public 

class  
LoggingConfiguration %
{ 
public 
bool !
EnableDatabaseTracing )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 
LogLevel 
DatabaseLogLevel (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
=7 8
LogLevel9 A
.A B
InformationB M
;M N
public		 
bool		 
EnableApiLogging		 $
{		% &
get		' *
;		* +
set		, /
;		/ 0
}		1 2
public

 
LogLevel

 
ApiLogLevel

 #
{

$ %
get

& )
;

) *
set

+ .
;

. /
}

0 1
=

2 3
LogLevel

4 <
.

< =
Information

= H
;

H I
} 
} Ø
vC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Common\Configurations\JwtConfiguration.cs
	namespace 	
FanPage
 
. 
Common 
. 
Configurations '
{ 
public 

class 
JwtConfiguration !
{ 
public 
TimeSpan 
LifeTime  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
string 
? 
Key 
{ 
get  
;  !
set" %
;% &
}' (
public		 
TimeSpan		 
BlackListLifeTime		 )
{		* +
get		, /
;		/ 0
set		1 4
;		4 5
}		6 7
}

 
} ª
yC:\Users\pavlo\source\repos\NonamePoc\FanPage\server\FanPage.Backend\FanPage.Common\Configurations\GoogleConfiguration.cs
	namespace 	
FanPage
 
. 
Common 
. 
Configurations '
;' (
public 
class 
GoogleConfiguration  
{ 
public 

string 
GoogleClientId !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 

string 
GoogleClientSecret %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
} 