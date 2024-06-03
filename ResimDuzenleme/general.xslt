<?xml version="1.0" encoding="UTF-8"?>
	<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:cac="urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2"
	xmlns:cbc="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2"
	xmlns:ccts="urn:un:unece:uncefact:documentation:2"
	xmlns:clm54217="urn:un:unece:uncefact:codelist:specification:54217:2001"
	xmlns:clm5639="urn:un:unece:uncefact:codelist:specification:5639:1988"
	xmlns:clm66411="urn:un:unece:uncefact:codelist:specification:66411:2001"
	xmlns:clmIANAMIMEMediaType="urn:un:unece:uncefact:codelist:specification:IANAMIMEMediaType:2003"
	xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:link="http://www.xbrl.org/2003/linkbase"
	xmlns:n1="urn:oasis:names:specification:ubl:schema:xsd:Invoice-2"
	xmlns:qdt="urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2"
	xmlns:udt="urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2"
	xmlns:xbrldi="http://xbrl.org/2006/xbrldi" xmlns:xbrli="http://www.xbrl.org/2003/instance"
	xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xlink="http://www.w3.org/1999/xlink"
	xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsd="http://www.w3.org/2001/XMLSchema"
	xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
	exclude-result-prefixes="cac cbc ccts clm54217 clm5639 clm66411 clmIANAMIMEMediaType fn link n1 qdt udt xbrldi xbrli xdt xlink xs xsd xsi">
	<xsl:decimal-format name="european" decimal-separator="," grouping-separator="." NaN=""/>
<xsl:output version="4.0" method="html" indent="no" encoding="UTF-8"
	doctype-public="-//W3C//DTD HTML 4.01 Transitional//EN"
	doctype-system="http://www.w3.org/TR/html4/loose.dtd"/>
<xsl:param name="SV_OutputFormat" select="'HTML'"/>

<xsl:template name="repNL">
  <xsl:param name="pText" select="."/>
  <xsl:if test="not(contains(substring(substring-before(concat($pText,'&#xA;'),'&#xA;'),0,8), '##') and not(contains(substring-before(concat($pText,'&#xA;'),'&#xA;'), '##internetSatis'))) and string-length(substring-before(concat($pText,'&#xA;'),'&#xA;'))>3">
  	<xsl:choose>
  	<xsl:when test="contains(substring-before(concat($pText,'&#xA;'),'&#xA;'), '##internetSatis')">
  		<b>* </b>  <xsl:copy-of select="substring-after(substring-after(substring-before(concat($pText,'&#xA;'),'&#xA;'),'##'),'#')"/><br />
  	</xsl:when>
  	<xsl:otherwise>
  		<b>* </b>  <xsl:copy-of select="substring-before(concat($pText,'&#xA;'),'&#xA;')"/><br />
  	</xsl:otherwise>
  	</xsl:choose>
	</xsl:if>
  <xsl:if test="contains($pText, '&#xA;')">
  	
   <xsl:call-template name="repNL">
    <xsl:with-param name="pText" select=
    "substring-after($pText, '&#xA;')"/>
   </xsl:call-template>
  </xsl:if>
 </xsl:template>

<xsl:template name="repNL2">
  <xsl:param name="pText" select="."/>
  <xsl:if test="contains(substring(substring-before(concat($pText,'&#xA;'),'&#xA;'),0,8), '##') and not(contains(substring-before(concat($pText,'&#xA;'),'&#xA;'), '##internetSatis'))">
  	<tr>
		<th><xsl:copy-of select="substring-after(substring-before(substring-before(concat($pText,'&#xA;'),'&#xA;'),':'),'##')"></xsl:copy-of>:</th>
		<td><xsl:copy-of select="substring-after(substring-before(concat($pText,'&#xA;'),'&#xA;'),':')"></xsl:copy-of></td>
		</tr>
	</xsl:if>
  <xsl:if test="contains($pText, '&#xA;')">
   <xsl:call-template name="repNL2">
    <xsl:with-param name="pText" select=
    "substring-after($pText, '&#xA;')"/>
   </xsl:call-template>
  </xsl:if>
 </xsl:template>

<xsl:variable name="XML" select="/"/>
<xsl:template name="removeLeadingZeros">
<xsl:param name="originalString"/>
	<xsl:choose>
		<xsl:when test="starts-with($originalString,'0')">
			<xsl:call-template name="removeLeadingZeros">
				<xsl:with-param name="originalString">
					<xsl:value-of select="substring-after($originalString,'0' )"/>
				</xsl:with-param>
			</xsl:call-template>
		</xsl:when>
		<xsl:otherwise>
			<xsl:value-of select="$originalString"/>
		</xsl:otherwise>
	</xsl:choose>
</xsl:template>
		<xsl:template match="/">
	<xsl:comment>eFinans Şablon Tasarım Aracı İle Hazırlanmıştır.</xsl:comment>
	<html>
	<head>
	<script type="text/javascript">
                    <![CDATA[var QRCode;!function(){function a(a){this.mode=c.MODE_8BIT_BYTE,this.data=a,this.parsedData=[];for(var b=[],d=0,e=this.data.length;e>d;d++){var f=this.data.charCodeAt(d);f>65536?(b[0]=240|(1835008&f)>>>18,b[1]=128|(258048&f)>>>12,b[2]=128|(4032&f)>>>6,b[3]=128|63&f):f>2048?(b[0]=224|(61440&f)>>>12,b[1]=128|(4032&f)>>>6,b[2]=128|63&f):f>128?(b[0]=192|(1984&f)>>>6,b[1]=128|63&f):b[0]=f,this.parsedData=this.parsedData.concat(b)}this.parsedData.length!=this.data.length&&(this.parsedData.unshift(191),this.parsedData.unshift(187),this.parsedData.unshift(239))}function b(a,b){this.typeNumber=a,this.errorCorrectLevel=b,this.modules=null,this.moduleCount=0,this.dataCache=null,this.dataList=[]}function i(a,b){if(void 0==a.length)throw new Error(a.length+"/"+b);for(var c=0;c<a.length&&0==a[c];)c++;this.num=new Array(a.length-c+b);for(var d=0;d<a.length-c;d++)this.num[d]=a[d+c]}function j(a,b){this.totalCount=a,this.dataCount=b}function k(){this.buffer=[],this.length=0}function m(){return"undefined"!=typeof CanvasRenderingContext2D}function n(){var a=!1,b=navigator.userAgent;return/android/i.test(b)&&(a=!0,aMat=b.toString().match(/android ([0-9]\.[0-9])/i),aMat&&aMat[1]&&(a=parseFloat(aMat[1]))),a}function r(a,b){for(var c=1,e=s(a),f=0,g=l.length;g>=f;f++){var h=0;switch(b){case d.L:h=l[f][0];break;case d.M:h=l[f][1];break;case d.Q:h=l[f][2];break;case d.H:h=l[f][3]}if(h>=e)break;c++}if(c>l.length)throw new Error("Too long data");return c}function s(a){var b=encodeURI(a).toString().replace(/\%[0-9a-fA-F]{2}/g,"a");return b.length+(b.length!=a?3:0)}a.prototype={getLength:function(){return this.parsedData.length},write:function(a){for(var b=0,c=this.parsedData.length;c>b;b++)a.put(this.parsedData[b],8)}},b.prototype={addData:function(b){var c=new a(b);this.dataList.push(c),this.dataCache=null},isDark:function(a,b){if(0>a||this.moduleCount<=a||0>b||this.moduleCount<=b)throw new Error(a+","+b);return this.modules[a][b]},getModuleCount:function(){return this.moduleCount},make:function(){this.makeImpl(!1,this.getBestMaskPattern())},makeImpl:function(a,c){this.moduleCount=4*this.typeNumber+17,this.modules=new Array(this.moduleCount);for(var d=0;d<this.moduleCount;d++){this.modules[d]=new Array(this.moduleCount);for(var e=0;e<this.moduleCount;e++)this.modules[d][e]=null}this.setupPositionProbePattern(0,0),this.setupPositionProbePattern(this.moduleCount-7,0),this.setupPositionProbePattern(0,this.moduleCount-7),this.setupPositionAdjustPattern(),this.setupTimingPattern(),this.setupTypeInfo(a,c),this.typeNumber>=7&&this.setupTypeNumber(a),null==this.dataCache&&(this.dataCache=b.createData(this.typeNumber,this.errorCorrectLevel,this.dataList)),this.mapData(this.dataCache,c)},setupPositionProbePattern:function(a,b){for(var c=-1;7>=c;c++)if(!(-1>=a+c||this.moduleCount<=a+c))for(var d=-1;7>=d;d++)-1>=b+d||this.moduleCount<=b+d||(this.modules[a+c][b+d]=c>=0&&6>=c&&(0==d||6==d)||d>=0&&6>=d&&(0==c||6==c)||c>=2&&4>=c&&d>=2&&4>=d?!0:!1)},getBestMaskPattern:function(){for(var a=0,b=0,c=0;8>c;c++){this.makeImpl(!0,c);var d=f.getLostPoint(this);(0==c||a>d)&&(a=d,b=c)}return b},createMovieClip:function(a,b,c){var d=a.createEmptyMovieClip(b,c),e=1;this.make();for(var f=0;f<this.modules.length;f++)for(var g=f*e,h=0;h<this.modules[f].length;h++){var i=h*e,j=this.modules[f][h];j&&(d.beginFill(0,100),d.moveTo(i,g),d.lineTo(i+e,g),d.lineTo(i+e,g+e),d.lineTo(i,g+e),d.endFill())}return d},setupTimingPattern:function(){for(var a=8;a<this.moduleCount-8;a++)null==this.modules[a][6]&&(this.modules[a][6]=0==a%2);for(var b=8;b<this.moduleCount-8;b++)null==this.modules[6][b]&&(this.modules[6][b]=0==b%2)},setupPositionAdjustPattern:function(){for(var a=f.getPatternPosition(this.typeNumber),b=0;b<a.length;b++)for(var c=0;c<a.length;c++){var d=a[b],e=a[c];if(null==this.modules[d][e])for(var g=-2;2>=g;g++)for(var h=-2;2>=h;h++)this.modules[d+g][e+h]=-2==g||2==g||-2==h||2==h||0==g&&0==h?!0:!1}},setupTypeNumber:function(a){for(var b=f.getBCHTypeNumber(this.typeNumber),c=0;18>c;c++){var d=!a&&1==(1&b>>c);this.modules[Math.floor(c/3)][c%3+this.moduleCount-8-3]=d}for(var c=0;18>c;c++){var d=!a&&1==(1&b>>c);this.modules[c%3+this.moduleCount-8-3][Math.floor(c/3)]=d}},setupTypeInfo:function(a,b){for(var c=this.errorCorrectLevel<<3|b,d=f.getBCHTypeInfo(c),e=0;15>e;e++){var g=!a&&1==(1&d>>e);6>e?this.modules[e][8]=g:8>e?this.modules[e+1][8]=g:this.modules[this.moduleCount-15+e][8]=g}for(var e=0;15>e;e++){var g=!a&&1==(1&d>>e);8>e?this.modules[8][this.moduleCount-e-1]=g:9>e?this.modules[8][15-e-1+1]=g:this.modules[8][15-e-1]=g}this.modules[this.moduleCount-8][8]=!a},mapData:function(a,b){for(var c=-1,d=this.moduleCount-1,e=7,g=0,h=this.moduleCount-1;h>0;h-=2)for(6==h&&h--;;){for(var i=0;2>i;i++)if(null==this.modules[d][h-i]){var j=!1;g<a.length&&(j=1==(1&a[g]>>>e));var k=f.getMask(b,d,h-i);k&&(j=!j),this.modules[d][h-i]=j,e--,-1==e&&(g++,e=7)}if(d+=c,0>d||this.moduleCount<=d){d-=c,c=-c;break}}}},b.PAD0=236,b.PAD1=17,b.createData=function(a,c,d){for(var e=j.getRSBlocks(a,c),g=new k,h=0;h<d.length;h++){var i=d[h];g.put(i.mode,4),g.put(i.getLength(),f.getLengthInBits(i.mode,a)),i.write(g)}for(var l=0,h=0;h<e.length;h++)l+=e[h].dataCount;if(g.getLengthInBits()>8*l)throw new Error("code length overflow. ("+g.getLengthInBits()+">"+8*l+")");for(g.getLengthInBits()+4<=8*l&&g.put(0,4);0!=g.getLengthInBits()%8;)g.putBit(!1);for(;;){if(g.getLengthInBits()>=8*l)break;if(g.put(b.PAD0,8),g.getLengthInBits()>=8*l)break;g.put(b.PAD1,8)}return b.createBytes(g,e)},b.createBytes=function(a,b){for(var c=0,d=0,e=0,g=new Array(b.length),h=new Array(b.length),j=0;j<b.length;j++){var k=b[j].dataCount,l=b[j].totalCount-k;d=Math.max(d,k),e=Math.max(e,l),g[j]=new Array(k);for(var m=0;m<g[j].length;m++)g[j][m]=255&a.buffer[m+c];c+=k;var n=f.getErrorCorrectPolynomial(l),o=new i(g[j],n.getLength()-1),p=o.mod(n);h[j]=new Array(n.getLength()-1);for(var m=0;m<h[j].length;m++){var q=m+p.getLength()-h[j].length;h[j][m]=q>=0?p.get(q):0}}for(var r=0,m=0;m<b.length;m++)r+=b[m].totalCount;for(var s=new Array(r),t=0,m=0;d>m;m++)for(var j=0;j<b.length;j++)m<g[j].length&&(s[t++]=g[j][m]);for(var m=0;e>m;m++)for(var j=0;j<b.length;j++)m<h[j].length&&(s[t++]=h[j][m]);return s};for(var c={MODE_NUMBER:1,MODE_ALPHA_NUM:2,MODE_8BIT_BYTE:4,MODE_KANJI:8},d={L:1,M:0,Q:3,H:2},e={PATTERN000:0,PATTERN001:1,PATTERN010:2,PATTERN011:3,PATTERN100:4,PATTERN101:5,PATTERN110:6,PATTERN111:7},f={PATTERN_POSITION_TABLE:[[],[6,18],[6,22],[6,26],[6,30],[6,34],[6,22,38],[6,24,42],[6,26,46],[6,28,50],[6,30,54],[6,32,58],[6,34,62],[6,26,46,66],[6,26,48,70],[6,26,50,74],[6,30,54,78],[6,30,56,82],[6,30,58,86],[6,34,62,90],[6,28,50,72,94],[6,26,50,74,98],[6,30,54,78,102],[6,28,54,80,106],[6,32,58,84,110],[6,30,58,86,114],[6,34,62,90,118],[6,26,50,74,98,122],[6,30,54,78,102,126],[6,26,52,78,104,130],[6,30,56,82,108,134],[6,34,60,86,112,138],[6,30,58,86,114,142],[6,34,62,90,118,146],[6,30,54,78,102,126,150],[6,24,50,76,102,128,154],[6,28,54,80,106,132,158],[6,32,58,84,110,136,162],[6,26,54,82,110,138,166],[6,30,58,86,114,142,170]],G15:1335,G18:7973,G15_MASK:21522,getBCHTypeInfo:function(a){for(var b=a<<10;f.getBCHDigit(b)-f.getBCHDigit(f.G15)>=0;)b^=f.G15<<f.getBCHDigit(b)-f.getBCHDigit(f.G15);return(a<<10|b)^f.G15_MASK},getBCHTypeNumber:function(a){for(var b=a<<12;f.getBCHDigit(b)-f.getBCHDigit(f.G18)>=0;)b^=f.G18<<f.getBCHDigit(b)-f.getBCHDigit(f.G18);return a<<12|b},getBCHDigit:function(a){for(var b=0;0!=a;)b++,a>>>=1;return b},getPatternPosition:function(a){return f.PATTERN_POSITION_TABLE[a-1]},getMask:function(a,b,c){switch(a){case e.PATTERN000:return 0==(b+c)%2;case e.PATTERN001:return 0==b%2;case e.PATTERN010:return 0==c%3;case e.PATTERN011:return 0==(b+c)%3;case e.PATTERN100:return 0==(Math.floor(b/2)+Math.floor(c/3))%2;case e.PATTERN101:return 0==b*c%2+b*c%3;case e.PATTERN110:return 0==(b*c%2+b*c%3)%2;case e.PATTERN111:return 0==(b*c%3+(b+c)%2)%2;default:throw new Error("bad maskPattern:"+a)}},getErrorCorrectPolynomial:function(a){for(var b=new i([1],0),c=0;a>c;c++)b=b.multiply(new i([1,g.gexp(c)],0));return b},getLengthInBits:function(a,b){if(b>=1&&10>b)switch(a){case c.MODE_NUMBER:return 10;case c.MODE_ALPHA_NUM:return 9;case c.MODE_8BIT_BYTE:return 8;case c.MODE_KANJI:return 8;default:throw new Error("mode:"+a)}else if(27>b)switch(a){case c.MODE_NUMBER:return 12;case c.MODE_ALPHA_NUM:return 11;case c.MODE_8BIT_BYTE:return 16;case c.MODE_KANJI:return 10;default:throw new Error("mode:"+a)}else{if(!(41>b))throw new Error("type:"+b);switch(a){case c.MODE_NUMBER:return 14;case c.MODE_ALPHA_NUM:return 13;case c.MODE_8BIT_BYTE:return 16;case c.MODE_KANJI:return 12;default:throw new Error("mode:"+a)}}},getLostPoint:function(a){for(var b=a.getModuleCount(),c=0,d=0;b>d;d++)for(var e=0;b>e;e++){for(var f=0,g=a.isDark(d,e),h=-1;1>=h;h++)if(!(0>d+h||d+h>=b))for(var i=-1;1>=i;i++)0>e+i||e+i>=b||(0!=h||0!=i)&&g==a.isDark(d+h,e+i)&&f++;f>5&&(c+=3+f-5)}for(var d=0;b-1>d;d++)for(var e=0;b-1>e;e++){var j=0;a.isDark(d,e)&&j++,a.isDark(d+1,e)&&j++,a.isDark(d,e+1)&&j++,a.isDark(d+1,e+1)&&j++,(0==j||4==j)&&(c+=3)}for(var d=0;b>d;d++)for(var e=0;b-6>e;e++)a.isDark(d,e)&&!a.isDark(d,e+1)&&a.isDark(d,e+2)&&a.isDark(d,e+3)&&a.isDark(d,e+4)&&!a.isDark(d,e+5)&&a.isDark(d,e+6)&&(c+=40);for(var e=0;b>e;e++)for(var d=0;b-6>d;d++)a.isDark(d,e)&&!a.isDark(d+1,e)&&a.isDark(d+2,e)&&a.isDark(d+3,e)&&a.isDark(d+4,e)&&!a.isDark(d+5,e)&&a.isDark(d+6,e)&&(c+=40);for(var k=0,e=0;b>e;e++)for(var d=0;b>d;d++)a.isDark(d,e)&&k++;var l=Math.abs(100*k/b/b-50)/5;return c+=10*l}},g={glog:function(a){if(1>a)throw new Error("glog("+a+")");return g.LOG_TABLE[a]},gexp:function(a){for(;0>a;)a+=255;for(;a>=256;)a-=255;return g.EXP_TABLE[a]},EXP_TABLE:new Array(256),LOG_TABLE:new Array(256)},h=0;8>h;h++)g.EXP_TABLE[h]=1<<h;for(var h=8;256>h;h++)g.EXP_TABLE[h]=g.EXP_TABLE[h-4]^g.EXP_TABLE[h-5]^g.EXP_TABLE[h-6]^g.EXP_TABLE[h-8];for(var h=0;255>h;h++)g.LOG_TABLE[g.EXP_TABLE[h]]=h;i.prototype={get:function(a){return this.num[a]},getLength:function(){return this.num.length},multiply:function(a){for(var b=new Array(this.getLength()+a.getLength()-1),c=0;c<this.getLength();c++)for(var d=0;d<a.getLength();d++)b[c+d]^=g.gexp(g.glog(this.get(c))+g.glog(a.get(d)));return new i(b,0)},mod:function(a){if(this.getLength()-a.getLength()<0)return this;for(var b=g.glog(this.get(0))-g.glog(a.get(0)),c=new Array(this.getLength()),d=0;d<this.getLength();d++)c[d]=this.get(d);for(var d=0;d<a.getLength();d++)c[d]^=g.gexp(g.glog(a.get(d))+b);return new i(c,0).mod(a)}},j.RS_BLOCK_TABLE=[[1,26,19],[1,26,16],[1,26,13],[1,26,9],[1,44,34],[1,44,28],[1,44,22],[1,44,16],[1,70,55],[1,70,44],[2,35,17],[2,35,13],[1,100,80],[2,50,32],[2,50,24],[4,25,9],[1,134,108],[2,67,43],[2,33,15,2,34,16],[2,33,11,2,34,12],[2,86,68],[4,43,27],[4,43,19],[4,43,15],[2,98,78],[4,49,31],[2,32,14,4,33,15],[4,39,13,1,40,14],[2,121,97],[2,60,38,2,61,39],[4,40,18,2,41,19],[4,40,14,2,41,15],[2,146,116],[3,58,36,2,59,37],[4,36,16,4,37,17],[4,36,12,4,37,13],[2,86,68,2,87,69],[4,69,43,1,70,44],[6,43,19,2,44,20],[6,43,15,2,44,16],[4,101,81],[1,80,50,4,81,51],[4,50,22,4,51,23],[3,36,12,8,37,13],[2,116,92,2,117,93],[6,58,36,2,59,37],[4,46,20,6,47,21],[7,42,14,4,43,15],[4,133,107],[8,59,37,1,60,38],[8,44,20,4,45,21],[12,33,11,4,34,12],[3,145,115,1,146,116],[4,64,40,5,65,41],[11,36,16,5,37,17],[11,36,12,5,37,13],[5,109,87,1,110,88],[5,65,41,5,66,42],[5,54,24,7,55,25],[11,36,12],[5,122,98,1,123,99],[7,73,45,3,74,46],[15,43,19,2,44,20],[3,45,15,13,46,16],[1,135,107,5,136,108],[10,74,46,1,75,47],[1,50,22,15,51,23],[2,42,14,17,43,15],[5,150,120,1,151,121],[9,69,43,4,70,44],[17,50,22,1,51,23],[2,42,14,19,43,15],[3,141,113,4,142,114],[3,70,44,11,71,45],[17,47,21,4,48,22],[9,39,13,16,40,14],[3,135,107,5,136,108],[3,67,41,13,68,42],[15,54,24,5,55,25],[15,43,15,10,44,16],[4,144,116,4,145,117],[17,68,42],[17,50,22,6,51,23],[19,46,16,6,47,17],[2,139,111,7,140,112],[17,74,46],[7,54,24,16,55,25],[34,37,13],[4,151,121,5,152,122],[4,75,47,14,76,48],[11,54,24,14,55,25],[16,45,15,14,46,16],[6,147,117,4,148,118],[6,73,45,14,74,46],[11,54,24,16,55,25],[30,46,16,2,47,17],[8,132,106,4,133,107],[8,75,47,13,76,48],[7,54,24,22,55,25],[22,45,15,13,46,16],[10,142,114,2,143,115],[19,74,46,4,75,47],[28,50,22,6,51,23],[33,46,16,4,47,17],[8,152,122,4,153,123],[22,73,45,3,74,46],[8,53,23,26,54,24],[12,45,15,28,46,16],[3,147,117,10,148,118],[3,73,45,23,74,46],[4,54,24,31,55,25],[11,45,15,31,46,16],[7,146,116,7,147,117],[21,73,45,7,74,46],[1,53,23,37,54,24],[19,45,15,26,46,16],[5,145,115,10,146,116],[19,75,47,10,76,48],[15,54,24,25,55,25],[23,45,15,25,46,16],[13,145,115,3,146,116],[2,74,46,29,75,47],[42,54,24,1,55,25],[23,45,15,28,46,16],[17,145,115],[10,74,46,23,75,47],[10,54,24,35,55,25],[19,45,15,35,46,16],[17,145,115,1,146,116],[14,74,46,21,75,47],[29,54,24,19,55,25],[11,45,15,46,46,16],[13,145,115,6,146,116],[14,74,46,23,75,47],[44,54,24,7,55,25],[59,46,16,1,47,17],[12,151,121,7,152,122],[12,75,47,26,76,48],[39,54,24,14,55,25],[22,45,15,41,46,16],[6,151,121,14,152,122],[6,75,47,34,76,48],[46,54,24,10,55,25],[2,45,15,64,46,16],[17,152,122,4,153,123],[29,74,46,14,75,47],[49,54,24,10,55,25],[24,45,15,46,46,16],[4,152,122,18,153,123],[13,74,46,32,75,47],[48,54,24,14,55,25],[42,45,15,32,46,16],[20,147,117,4,148,118],[40,75,47,7,76,48],[43,54,24,22,55,25],[10,45,15,67,46,16],[19,148,118,6,149,119],[18,75,47,31,76,48],[34,54,24,34,55,25],[20,45,15,61,46,16]],j.getRSBlocks=function(a,b){var c=j.getRsBlockTable(a,b);if(void 0==c)throw new Error("bad rs block @ typeNumber:"+a+"/errorCorrectLevel:"+b);for(var d=c.length/3,e=[],f=0;d>f;f++)for(var g=c[3*f+0],h=c[3*f+1],i=c[3*f+2],k=0;g>k;k++)e.push(new j(h,i));return e},j.getRsBlockTable=function(a,b){switch(b){case d.L:return j.RS_BLOCK_TABLE[4*(a-1)+0];case d.M:return j.RS_BLOCK_TABLE[4*(a-1)+1];case d.Q:return j.RS_BLOCK_TABLE[4*(a-1)+2];case d.H:return j.RS_BLOCK_TABLE[4*(a-1)+3];default:return void 0}},k.prototype={get:function(a){var b=Math.floor(a/8);return 1==(1&this.buffer[b]>>>7-a%8)},put:function(a,b){for(var c=0;b>c;c++)this.putBit(1==(1&a>>>b-c-1))},getLengthInBits:function(){return this.length},putBit:function(a){var b=Math.floor(this.length/8);this.buffer.length<=b&&this.buffer.push(0),a&&(this.buffer[b]|=128>>>this.length%8),this.length++}};var l=[[17,14,11,7],[32,26,20,14],[53,42,32,24],[78,62,46,34],[106,84,60,44],[134,106,74,58],[154,122,86,64],[192,152,108,84],[230,180,130,98],[271,213,151,119],[321,251,177,137],[367,287,203,155],[425,331,241,177],[458,362,258,194],[520,412,292,220],[586,450,322,250],[644,504,364,280],[718,560,394,310],[792,624,442,338],[858,666,482,382],[929,711,509,403],[1003,779,565,439],[1091,857,611,461],[1171,911,661,511],[1273,997,715,535],[1367,1059,751,593],[1465,1125,805,625],[1528,1190,868,658],[1628,1264,908,698],[1732,1370,982,742],[1840,1452,1030,790],[1952,1538,1112,842],[2068,1628,1168,898],[2188,1722,1228,958],[2303,1809,1283,983],[2431,1911,1351,1051],[2563,1989,1423,1093],[2699,2099,1499,1139],[2809,2213,1579,1219],[2953,2331,1663,1273]],o=function(){var a=function(a,b){this._el=a,this._htOption=b};return a.prototype.draw=function(a){function g(a,b){var c=document.createElementNS("http://www.w3.org/2000/svg",a);for(var d in b)b.hasOwnProperty(d)&&c.setAttribute(d,b[d]);return c}var b=this._htOption,c=this._el,d=a.getModuleCount();Math.floor(b.width/d),Math.floor(b.height/d),this.clear();var h=g("svg",{viewBox:"0 0 "+String(d)+" "+String(d),width:"100%",height:"100%",fill:b.colorLight});h.setAttributeNS("http://www.w3.org/2000/xmlns/","xmlns:xlink","http://www.w3.org/1999/xlink"),c.appendChild(h),h.appendChild(g("rect",{fill:b.colorDark,width:"1",height:"1",id:"template"}));for(var i=0;d>i;i++)for(var j=0;d>j;j++)if(a.isDark(i,j)){var k=g("use",{x:String(i),y:String(j)});k.setAttributeNS("http://www.w3.org/1999/xlink","href","#template"),h.appendChild(k)}},a.prototype.clear=function(){for(;this._el.hasChildNodes();)this._el.removeChild(this._el.lastChild)},a}(),p="svg"===document.documentElement.tagName.toLowerCase(),q=p?o:m()?function(){function a(){this._elImage.src=this._elCanvas.toDataURL("image/png"),this._elImage.style.display="block",this._elImage.style.margin="auto",this._elCanvas.style.display="none"}function d(a,b){var c=this;if(c._fFail=b,c._fSuccess=a,null===c._bSupportDataURI){var d=document.createElement("img"),e=function(){c._bSupportDataURI=!1,c._fFail&&_fFail.call(c)},f=function(){c._bSupportDataURI=!0,c._fSuccess&&c._fSuccess.call(c)};return d.onabort=e,d.onerror=e,d.onload=f,d.src="data:image/gif;base64,iVBORw0KGgoAAAANSUhEUgAAAAUAAAAFCAYAAACNbyblAAAAHElEQVQI12P4//8/w38GIAXDIBKE0DHxgljNBAAO9TXL0Y4OHwAAAABJRU5ErkJggg==",void 0}c._bSupportDataURI===!0&&c._fSuccess?c._fSuccess.call(c):c._bSupportDataURI===!1&&c._fFail&&c._fFail.call(c)}if(this._android&&this._android<=2.1){var b=1/window.devicePixelRatio,c=CanvasRenderingContext2D.prototype.drawImage;CanvasRenderingContext2D.prototype.drawImage=function(a,d,e,f,g,h,i,j){if("nodeName"in a&&/img/i.test(a.nodeName))for(var l=arguments.length-1;l>=1;l--)arguments[l]=arguments[l]*b;else"undefined"==typeof j&&(arguments[1]*=b,arguments[2]*=b,arguments[3]*=b,arguments[4]*=b);c.apply(this,arguments)}}var e=function(a,b){this._bIsPainted=!1,this._android=n(),this._htOption=b,this._elCanvas=document.createElement("canvas"),this._elCanvas.width=b.width,this._elCanvas.height=b.height,a.appendChild(this._elCanvas),this._el=a,this._oContext=this._elCanvas.getContext("2d"),this._bIsPainted=!1,this._elImage=document.createElement("img"),this._elImage.style.display="none",this._el.appendChild(this._elImage),this._bSupportDataURI=null};return e.prototype.draw=function(a){var b=this._elImage,c=this._oContext,d=this._htOption,e=a.getModuleCount(),f=d.width/e,g=d.height/e,h=Math.round(f),i=Math.round(g);b.style.display="none",this.clear();for(var j=0;e>j;j++)for(var k=0;e>k;k++){var l=a.isDark(j,k),m=k*f,n=j*g;c.strokeStyle=l?d.colorDark:d.colorLight,c.lineWidth=1,c.fillStyle=l?d.colorDark:d.colorLight,c.fillRect(m,n,f,g),c.strokeRect(Math.floor(m)+.5,Math.floor(n)+.5,h,i),c.strokeRect(Math.ceil(m)-.5,Math.ceil(n)-.5,h,i)}this._bIsPainted=!0},e.prototype.makeImage=function(){this._bIsPainted&&d.call(this,a)},e.prototype.isPainted=function(){return this._bIsPainted},e.prototype.clear=function(){this._oContext.clearRect(0,0,this._elCanvas.width,this._elCanvas.height),this._bIsPainted=!1},e.prototype.round=function(a){return a?Math.floor(1e3*a)/1e3:a},e}():function(){var a=function(a,b){this._el=a,this._htOption=b};return a.prototype.draw=function(a){for(var b=this._htOption,c=this._el,d=a.getModuleCount(),e=Math.floor(b.width/d),f=Math.floor(b.height/d),g=['<table style="border:0;border-collapse:collapse;">'],h=0;d>h;h++){g.push("<tr>");for(var i=0;d>i;i++)g.push('<td style="border:0;border-collapse:collapse;padding:0;margin:0;width:'+e+"px;height:"+f+"px;background-color:"+(a.isDark(h,i)?b.colorDark:b.colorLight)+';"></td>');g.push("</tr>")}g.push("</table>"),c.innerHTML=g.join("");var j=c.childNodes[0],k=(b.width-j.offsetWidth)/2,l=(b.height-j.offsetHeight)/2;k>0&&l>0&&(j.style.margin=l+"px "+k+"px")},a.prototype.clear=function(){this._el.innerHTML=""},a}();QRCode=function(a,b){if(this._htOption={width:256,height:256,typeNumber:4,colorDark:"#000000",colorLight:"#ffffff",correctLevel:d.H},"string"==typeof b&&(b={text:b}),b)for(var c in b)this._htOption[c]=b[c];"string"==typeof a&&(a=document.getElementById(a)),this._android=n(),this._el=a,this._oQRCode=null,this._oDrawing=new q(this._el,this._htOption),this._htOption.text&&this.makeCode(this._htOption.text)},QRCode.prototype.makeCode=function(a){this._oQRCode=new b(r(a,this._htOption.correctLevel),this._htOption.correctLevel),this._oQRCode.addData(a),this._oQRCode.make(),this._el.title=a,this._oDrawing.draw(this._oQRCode),this.makeImage()},QRCode.prototype.makeImage=function(){"function"==typeof this._oDrawing.makeImage&&(!this._android||this._android>=3)&&this._oDrawing.makeImage()},QRCode.prototype.clear=function(){this._oDrawing.clear()},QRCode.CorrectLevel=d}();]]>
                </script>
	<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<title>e-Arşiv Fatura</title>
<style type="text/css">
					.ph {overflow:hidden;max-height:250px;}
					.ph7 {text-align:center;margin-bottom:18px;}
					.ph8 img {margin-bottom: 18px;}
					.ph10 {
						float: left;
						width: 295px;
						margin-top: 14px;
						margin-right: 12px;
						padding: 8px;
					}

					body {
						margin: 7px 0 10px 0;
						text-align: center;
						background-color: #BBBBBB;
						font-family:Arial, Helvetica, sans-serif;
						background-image: url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABcAAAAXCAYAAADgKtSgAAABCElEQVR42p1VWw7DIAzL/S/Z10E2pZKRZ8UB9oEKxaSJbdJ4nudzHMcYucY73VvB5Po8z3ce13UNMB/SAdzOXtz33WaGwzlyXuHzHfDAvcGrA1ryLj2YhwvaacFUgF/O2gbXIFwVzzt9Bi1OTDdXR/C+VhFdgB3K+IkKY8XnSlNmqB+rqg8+xJ5ncWbcMg62zASiysxVoTp0exknVqw349hVEaq647zyuDPACD7LqhJu9aZG9cXO9xBsdg9+3AKFXa9gB610xpcW7WTVgIM0ASdmSYvLmC+Po2VLUCcyV8F9vAzeZbvbzLR5hevFDKrWjOO/EKr5uaH//IAVx3oMWhg847167yz8BYJMf2ivVbLJAAAAAElFTkSuQmCC);
					}
					.documentContainer a {pointer-events:none;}
					.documentContainer,
					.documentContainerOuter {
							margin: 0 auto;
							}
					@media screen {
					body {color: #666;}
					.documentContainer {
							max-width: 945px;
							min-width: 945px;
							overflow:hidden;
							text-align: left;
							box-sizing: border-box;
							display:inline-block;
							-webkit-box-shadow: 0 1px 4px rgba(0, 0, 0, 0.3), 0 0 40px rgba(0, 0, 0, 0.1) inset;
							-moz-box-shadow: 0 1px 4px rgba(0, 0, 0, 0.3), 0 0 40px rgba(0, 0, 0, 0.1) inset;
							box-shadow: 0 1px 4px rgba(0, 0, 0, 0.3), 0 0 40px rgba(0, 0, 0, 0.1) inset;
							background-color: white;
							position: relative;
							padding: 20px 20px 20px 28px;
						}
					
					.documentContainer:before, .documentContainer:after {
						content: "";
						position: absolute;
						z-index: -1;
						-webkit-box-shadow: 0 0 20px rgba(0,0,0,0.8);
						-moz-box-shadow: 0 0 20px rgba(0,0,0,0.8);
						box-shadow: 0 0 20px rgba(0,0,0,0.8);
						top: 50%;
						bottom: 0;
						left: 10px;
						right: 10px;
						-moz-border-radius: 100px / 10px;
						border-radius: 100px / 10px;
					}

					.documentContainer:after {
						right: 10px;
						left: auto;
						-webkit-transform: skew(8deg) rotate(3deg);
						-moz-transform: skew(8deg) rotate(3deg);
						-ms-transform: skew(8deg) rotate(3deg);
						-o-transform: skew(8deg) rotate(3deg);
						transform: skew(8deg) rotate(3deg);
					}
					}	

					#ustBolum{
						margin-top: 27px;
						margin-bottom: 15px;
					}
						.kutu {vertical-align: top;}
						
						.kutu table{float:none;}
						.gonderici {
							display: inline-block;
							padding: 8px 8px 8px 0;
							box-sizing: border-box;
						}
						.gonderici .partyName {font-weight:bold;}
						.alici {
							width: 370px;
							padding: 8px 4px 4px 0;
							box-sizing: border-box;
						}
						.alici .customerTitle {font-weight:bold;}
						.alici .kutu { border:1px solid #CCC; background-color:#F4F4F4;}
						
						#ETTN {
							margin-top: 7px;
							padding: 8px 4px 4px 0;
						}

						#despatchTable .placeHolder.companyLogo img {margin-bottom:18px;}
						
						#toplamlarContainer {overflow:hidden;}
						.toplamlar {float:right;width: 100%;}
						.toplamlar tr {text-align:right;}
						.toplamlar th {font-weight:normal;text-align:right;}
						.toplamlar table {width:238px;margin-top: 14px;border-spacing:0;}
						.toplamlar table td {font-weight: bold; width:25%; white-space:nowrap;min-width: 55px; vertical-align: top;
						}
						.toplamlar table th,
						.toplamlar table td{
							border-bottom: 1px solid #ccc;
							border-right: 1px solid #ccc;
							border-left: 1px solid #ccc;
							padding:3px;
						}
						.toplamlar table th {white-space:nowrap;border-right: none;}
						.toplamlar table th.is-long-true,
						#malHizmetTablosu > tbody > tr > td .is-long-true {white-space:pre-line;}
						.toplamlar table tr:first-child th,
						.toplamlar table tr:first-child td{
						border-top:1px solid #ccc;
						}
						.toplamlar table td span {font-weight:normal;color: #7C7C7C;}

						tr.payableAmount th:first-child {
							background-color: #f6f6f6;
						}

						tr.payableAmount td {
						background-color: #f6f6f6;
						}

						.toplamlar > div {
							display: inline-block;
						}
						.toplamTablo{
							margin-left: 31px;
							float:right;
						}
					#notlar {
						margin-top: 14px;
						border-top: 1px solid #DDD;
						overflow: hidden;
						padding-top: 8px;
						padding-bottom: 2px;

					}
					#notlar table {border:none;background:none;}
					.clearfix:before,
					.clearfix:after {
						content:"";
						display:table;
					}

					.box{display: inline-block;*display: inline;zoom: 1;width: 33%; box-sizing:border-box; vertical-align: top;}
					#b1{width: 40%;}
					#b2{width: 25%;}
					#b3{width: 35%;}
					#kunye {border-spacing:0;}
					#kunye tr{ border-bottom: 1px dotted #CCC;}
					#kunye td{ border:1px solid #CCC;border-top: none;padding:3px;width: 100%;}
					#kunye th{vertical-align:top;font-weight:bold;padding:3px;white-space: nowrap;border:1px solid #ccc;border-top: none;border-right: none;text-align:left;}
					#kunye tr:first-child td{border-top: 1px solid #ccc;}
					#kunye tr:first-child th{border-top: 1px solid #ccc;}
					#kunye td:nth-child(2) {word-break: break-all;}
					.satirlar {margin-top:20px;}
					#malHizmetTablosu
					{
						width:100%;
						font-family: "Lucida Sans Unicode", "Lucida Grande", Sans-Serif;
						background: #fff;
						border-collapse: collapse;
						text-align: right;
					}
					#malHizmetTablosu > tbody > tr > th
					{
						font-weight: normal;
						padding: 2px;
						text-align:right;
						color: black;
						padding-left: 3px;
						border-bottom: 2px solid #AAAAAA;
						background-color: #DFDFDF;
						border-right: 1px solid #B8B8B8;
						border-top: 1px solid #C5C5C5;
						padding-right: 5px;
						vertical-align: middle;
						min-height: 35px;
					}					
					#malHizmetTablosu > tbody > tr:first-child > th:first-child {border-left: 1px solid #B8B8B8;}
					#malHizmetTablosu > tbody > tr:first-child > th.mhColumn {min-width:72px;}
					#malHizmetTablosu > tbody > th > .thTopTitle {text-align:center;width: 89px;}
					#malHizmetTablosu > tbody > th .thSubTitle {width: 47px; display: inline-block;text-align: right;}
					#malHizmetTablosu > tbody > th .thSubTitle.HF {width:36px;}
					#malHizmetTablosu > tbody > tr > th.alignLeft {text-align:left;width: 40%;}

					#malHizmetTablosu > tbody > tr > td {
						white-space:nowrap;
						padding-left:3px;
						border-bottom: 1px solid #ccc;
						color: #000;
						border-right: 1px solid #ccc;
						padding-right: 3px;
						text-align:right;
						height:25px;
					}
					#malHizmetTablosu > tbody > tr > td.iskontoOrani {padding-left:0; padding-right:0;}
					#malHizmetTablosu > tbody > tr > td.iskontoOrani td{text-align: center;}
					#malHizmetTablosu > tbody > tr:hover > td {border-right: 1px solid #969696;border-bottom: 1px solid #969696;border-top: 1px solid #969696;}
					#malHizmetTablosu > tbody > tr > td.wrap {white-space:normal;text-align:left;}
					#malHizmetTablosu > tbody > tr > td:first-child,
					#malHizmetTablosu > tbody > tr > th:first-child {border-left: 1px solid #B8B8B8;}

					#malHizmetTablosu > tbody > tr:hover > td
					{
						background-color: #D1D1D1 !important;
						cursor:default;
					}
					#malHizmetTablosu > tbody > tr:nth-child(even) > td {background-color: #FFF}
					#malHizmetTablosu > tbody > tr:nth-child(odd) > td {background-color: #EEE}
					.sumValue {white-space:nowrap;}
					.iskontoOraniHeader,
					.iskontoOraniDegerler {width:100%;border-spacing:0;}
					.iskontoOraniHeader td {border-top: 1px solid #969696;}
					.iskontoOraniHeader td,
					.iskontoOraniDegerler td
					{border-left: 1px solid #969696;}
					.iskontoOraniHeader td:first-child,
					.iskontoOraniDegerler td:first-child {border-left:none;}
					@media print {
						body {color: #000;text-align: left;background:none;background-color:#ffffff;margin:0;}
						.documentContainer {padding:0;min-height: initial;width: 845px !important;}
						#malHizmetTablosu {width: 845px;}
					}
					
					body,table{font-size:12px;}

</style>
	<script>
	<![CDATA[!function(t){function e(r){if(n[r])return n[r].exports;var i=n[r]={i:r,l:!1,exports:{}};return t[r].call(i.exports,i,i.exports,e),i.l=!0,i.exports}var n={};return e.m=t,e.c=n,e.p="",e(e.s=10)}([function(t,e){"use strict";function n(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}Object.defineProperty(e,"__esModule",{value:!0});var r=function(){function t(){n(this,t),this.startBin="101",this.endBin="101",this.middleBin="01010",this.Lbinary=["0001101","0011001","0010011","0111101","0100011","0110001","0101111","0111011","0110111","0001011"],this.Gbinary=["0100111","0110011","0011011","0100001","0011101","0111001","0000101","0010001","0001001","0010111"],this.Rbinary=["1110010","1100110","1101100","1000010","1011100","1001110","1010000","1000100","1001000","1110100"]}return t.prototype.encode=function(t,e,n){var r="";n=n||"";for(var i=0;i<t.length;i++)"L"==e[i]?r+=this.Lbinary[t[i]]:"G"==e[i]?r+=this.Gbinary[t[i]]:"R"==e[i]&&(r+=this.Rbinary[t[i]]),i<t.length-1&&(r+=n);return r},t}();e["default"]=r},function(t,e){"use strict";function n(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}function r(t,e){for(var n=0;e>n;n++)t="0"+t;return t}Object.defineProperty(e,"__esModule",{value:!0});var i=function(){function t(e){n(this,t),this.string=e}return t.prototype.encode=function(){for(var t="110",e=0;e<this.string.length;e++){var n=parseInt(this.string[e]),i=n.toString(2);i=r(i,4-i.length);for(var o=0;o<i.length;o++)t+="0"==i[o]?"100":"110"}return t+="1001",{data:t,text:this.string}},t.prototype.valid=function(){return-1!==this.string.search(/^[0-9]+$/)},t}();e["default"]=i},function(t,e){"use strict";function n(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}Object.defineProperty(e,"__esModule",{value:!0});var r=function(){function t(e){n(this,t),this.bytes=[];for(var r=0;r<e.length;++r)this.bytes.push(e.charCodeAt(r));this.string=e.substring(1),this.encodings=[740,644,638,176,164,100,224,220,124,608,604,572,436,244,230,484,260,254,650,628,614,764,652,902,868,836,830,892,844,842,752,734,590,304,112,94,416,128,122,672,576,570,464,422,134,496,478,142,910,678,582,768,762,774,880,862,814,896,890,818,914,602,930,328,292,200,158,68,62,424,412,232,218,76,74,554,616,978,556,146,340,212,182,508,268,266,956,940,938,758,782,974,400,310,118,512,506,960,954,502,518,886,966,668,680,692,5379]}return t.prototype.encode=function(){var t,e=this.bytes,n=e.shift()-105;return 103===n?t=this.nextA(e,1):104===n?t=this.nextB(e,1):105===n&&(t=this.nextC(e,1)),{text:this.string.replace(/[^\x20-\x7E]/g,""),data:this.getEncoding(n)+t.result+this.getEncoding((t.checksum+n)%103)+this.getEncoding(106)}},t.prototype.getEncoding=function(t){return this.encodings[t]?(this.encodings[t]+1e3).toString(2):""},t.prototype.valid=function(){return-1!==this.string.search(/^[\x00-\x7F\xC8-\xD3]+$/)},t.prototype.nextA=function(t,e){if(t.length<=0)return{result:"",checksum:0};var n,r;if(t[0]>=200)r=t[0]-105,t.shift(),99===r?n=this.nextC(t,e+1):100===r?n=this.nextB(t,e+1):98===r?(t[0]=t[0]>95?t[0]-96:t[0],n=this.nextA(t,e+1)):n=this.nextA(t,e+1);else{var i=t[0];r=32>i?i+64:i-32,t.shift(),n=this.nextA(t,e+1)}var o=this.getEncoding(r),s=r*e;return{result:o+n.result,checksum:s+n.checksum}},t.prototype.nextB=function(t,e){if(t.length<=0)return{result:"",checksum:0};var n,r;t[0]>=200?(r=t[0]-105,t.shift(),99===r?n=this.nextC(t,e+1):101===r?n=this.nextA(t,e+1):98===r?(t[0]=t[0]<32?t[0]+96:t[0],n=this.nextB(t,e+1)):n=this.nextB(t,e+1)):(r=t[0]-32,t.shift(),n=this.nextB(t,e+1));var i=this.getEncoding(r),o=r*e;return{result:i+n.result,checksum:o+n.checksum}},t.prototype.nextC=function(t,e){if(t.length<=0)return{result:"",checksum:0};var n,r;t[0]>=200?(r=t[0]-105,t.shift(),n=100===r?this.nextB(t,e+1):101===r?this.nextA(t,e+1):this.nextC(t,e+1)):(r=10*(t[0]-48)+t[1]-48,t.shift(),t.shift(),n=this.nextC(t,e+1));var i=this.getEncoding(r),o=r*e;return{result:i+n.result,checksum:o+n.checksum}},t}();e["default"]=r},function(t,e){"use strict";function n(t){for(var e=0,n=0;n<t.length;n++){var r=parseInt(t[n]);e+=(n+t.length)%2===0?r:2*r%10+Math.floor(2*r/10)}return(10-e%10)%10}function r(t){for(var e=0,n=[2,3,4,5,6,7],r=0;r<t.length;r++){var i=parseInt(t[t.length-1-r]);e+=n[r%n.length]*i}return(11-e%11)%11}Object.defineProperty(e,"__esModule",{value:!0}),e.mod10=n,e.mod11=r},function(t,e){"use strict";function n(t,e){var n,r={};for(n in t)t.hasOwnProperty(n)&&(r[n]=t[n]);for(n in e)e.hasOwnProperty(n)&&"undefined"!=typeof e[n]&&(r[n]=e[n]);return r}Object.defineProperty(e,"__esModule",{value:!0}),e["default"]=n},function(t,e,n){"use strict";Object.defineProperty(e,"__esModule",{value:!0});var r=n(16),i=n(15),o=n(22),s=n(25),a=n(24),u=n(30),f=n(31),c=n(23);e["default"]={CODE39:r.CODE39,CODE128:i.CODE128,CODE128A:i.CODE128A,CODE128B:i.CODE128B,CODE128C:i.CODE128C,EAN13:o.EAN13,EAN8:o.EAN8,EAN5:o.EAN5,EAN2:o.EAN2,UPC:o.UPC,ITF14:s.ITF14,ITF:a.ITF,MSI:u.MSI,MSI10:u.MSI10,MSI11:u.MSI11,MSI1010:u.MSI1010,MSI1110:u.MSI1110,pharmacode:f.pharmacode,GenericBarcode:c.GenericBarcode}},function(t,e){"use strict";function n(t){return t.marginTop=t.marginTop||t.margin,t.marginBottom=t.marginBottom||t.margin,t.marginRight=t.marginRight||t.margin,t.marginLeft=t.marginLeft||t.margin,t}Object.defineProperty(e,"__esModule",{value:!0}),e["default"]=n},function(t,e,n){"use strict";function r(t){return t&&t.__esModule?t:{"default":t}}function i(t,e){var n={};for(var r in e)t.hasAttribute("jsbarcode-"+r.toLowerCase())&&(n[r]=t.getAttribute("jsbarcode-"+r.toLowerCase())),t.hasAttribute("data-"+r.toLowerCase())&&(n[r]=t.getAttribute("data-"+r.toLowerCase()));return n.value=t.getAttribute("jsbarcode-value")||t.getAttribute("data-value"),n=(0,s["default"])(n)}Object.defineProperty(e,"__esModule",{value:!0});var o=n(32),s=r(o);e["default"]=i},function(t,e){"use strict";function n(t){function e(t){if(Array.isArray(t))for(var r=0;r<t.length;r++)e(t[r]);else t.text=t.text||"",t.data=t.data||"",n.push(t)}var n=[];return e(t),n}Object.defineProperty(e,"__esModule",{value:!0}),e["default"]=n},function(t,e,n){"use strict";function r(t){return t&&t.__esModule?t:{"default":t}}Object.defineProperty(e,"__esModule",{value:!0});var i=n(33),o=r(i),s=n(34),a=r(s);e["default"]={canvas:o["default"],svg:a["default"]}},function(t,e,n){"use strict";function r(t){return t&&t.__esModule?t:{"default":t}}function i(t,e){_.prototype[e]=_.prototype[e.toUpperCase()]=_.prototype[e.toLowerCase()]=function(n,r){var i=(0,p["default"])(this._options,r),s=t[e],a=o(n,s,i);return this._encodings.push(a),this}}function o(t,e,n){var r=new e(t,n);if(!r.valid()){if(n.valid===E.valid)throw new Error('"'+t+'" is not a valid input for '+w);n.valid(!1)}var i=r.encode();i=(0,y["default"])(i);for(var o=0;o<i.length;o++)i[o].options=(0,p["default"])(n,i[o].options);return i}function s(){return c["default"].CODE128?"CODE128":Object.keys(c["default"])[0]}function a(t,e,n){var r=l["default"][t.renderer];e=(0,y["default"])(e);for(var i=0;i<e.length;i++)e[i].options=(0,p["default"])(n,e[i].options),(0,b["default"])(e[i].options);(0,b["default"])(n),r(t.element,e,n),t.afterRender&&t.afterRender()}function u(t){if("string"==typeof t){var e=document.querySelectorAll(t);if(0===e.length)throw new Error("No element found");for(var n=[],r=0;r<e.length;r++)n.push(u(e[r]));return n}if(Array.isArray(t)){for(var n=[],r=0;r<t.length;r++)n.push(u(t[r]));return n}if("undefined"!=typeof HTMLCanvasElement&&t instanceof HTMLImageElement){var i=document.createElement("canvas");return{element:i,options:(0,m["default"])(t,E),renderer:"canvas",afterRender:function(){t.setAttribute("src",i.toDataURL())}}}if("undefined"!=typeof SVGElement&&t instanceof SVGElement)return{element:t,options:(0,m["default"])(t,E),renderer:"svg"};if("undefined"!=typeof HTMLCanvasElement&&t instanceof HTMLCanvasElement)return{element:t,options:(0,m["default"])(t,E),renderer:"canvas"};if(t.getContext)return{element:t,renderer:"canvas"};throw new Error("Not supported type to render on.")}var f=n(5),c=r(f),h=n(9),l=r(h),d=n(4),p=r(d),g=n(8),y=r(g),v=n(6),b=r(v),x=n(7),m=r(x),_=function(){},C=function(t,e,n){var r=new _;if("undefined"==typeof t)throw Error("No element to render on was provided.");return r._renderProperties=u(t),r._encodings=[],r._options=E,"undefined"!=typeof e&&(n=n||{},n.format||(n.format=s()),r.options(n),r[n.format](e,n),r.render()),r};C.getModule=function(t){return c["default"][t]};for(var w in c["default"])c["default"].hasOwnProperty(w)&&i(c["default"],w);_.prototype.options=function(t){return this._options=(0,p["default"])(this._options,t),this},_.prototype.blank=function(t){var e="0".repeat(t);return this._encodings.push({data:e}),this},_.prototype.init=function(){Array.isArray(this._renderProperties)||(this._renderProperties=[this._renderProperties]);var t;for(var e in this._renderProperties){t=this._renderProperties[e];var n=(0,p["default"])(this._options,t.options);"auto"==n.format&&(n.format=s());var r=n.value,i=c["default"][n.format.toUpperCase()],u=o(r,i,n);a(t,u,n)}},_.prototype.render=function(){if(Array.isArray(this._renderProperties))for(var t in this._renderProperties)a(this._renderProperties[t],this._encodings,this._options);else a(this._renderProperties,this._encodings,this._options);return this._options.valid(!0),this},"undefined"!=typeof window&&(window.JsBarcode=C),"undefined"!=typeof jQuery&&(jQuery.fn.JsBarcode=function(t,e){var n=[];return jQuery(this).each(function(){n.push(this)}),C(n,t,e)}),t.exports=C;var E={width:2,height:100,format:"auto",displayValue:!0,fontOptions:"",font:"monospace",textAlign:"center",textPosition:"bottom",textMargin:2,fontSize:20,background:"#ffffff",lineColor:"#000000",margin:10,marginTop:void 0,marginBottom:void 0,marginLeft:void 0,marginRight:void 0,valid:function(t){}}},function(t,e,n){"use strict";function r(t){return t&&t.__esModule?t:{"default":t}}function i(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}function o(t,e){if(!t)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!e||"object"!=typeof e&&"function"!=typeof e?t:e}function s(t,e){if("function"!=typeof e&&null!==e)throw new TypeError("Super expression must either be null or a function, not "+typeof e);t.prototype=Object.create(e&&e.prototype,{constructor:{value:t,enumerable:!1,writable:!0,configurable:!0}}),e&&(Object.setPrototypeOf?Object.setPrototypeOf(t,e):t.__proto__=e)}Object.defineProperty(e,"__esModule",{value:!0});var a=n(2),u=r(a),f=function(t){function e(n){return i(this,e),o(this,t.call(this,String.fromCharCode(208)+n))}return s(e,t),e.prototype.valid=function(){return-1!==this.string.search(/^[\x00-\x5F\xC8-\xCF]+$/)},e}(u["default"]);e["default"]=f},function(t,e,n){"use strict";function r(t){return t&&t.__esModule?t:{"default":t}}function i(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}function o(t,e){if(!t)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!e||"object"!=typeof e&&"function"!=typeof e?t:e}function s(t,e){if("function"!=typeof e&&null!==e)throw new TypeError("Super expression must either be null or a function, not "+typeof e);t.prototype=Object.create(e&&e.prototype,{constructor:{value:t,enumerable:!1,writable:!0,configurable:!0}}),e&&(Object.setPrototypeOf?Object.setPrototypeOf(t,e):t.__proto__=e)}Object.defineProperty(e,"__esModule",{value:!0});var a=n(2),u=r(a),f=function(t){function e(n){return i(this,e),o(this,t.call(this,String.fromCharCode(209)+n))}return s(e,t),e.prototype.valid=function(){return-1!==this.string.search(/^[\x20-\x7F\xC8-\xCF]+$/)},e}(u["default"]);e["default"]=f},function(t,e,n){"use strict";function r(t){return t&&t.__esModule?t:{"default":t}}function i(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}function o(t,e){if(!t)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!e||"object"!=typeof e&&"function"!=typeof e?t:e}function s(t,e){if("function"!=typeof e&&null!==e)throw new TypeError("Super expression must either be null or a function, not "+typeof e);t.prototype=Object.create(e&&e.prototype,{constructor:{value:t,enumerable:!1,writable:!0,configurable:!0}}),e&&(Object.setPrototypeOf?Object.setPrototypeOf(t,e):t.__proto__=e)}Object.defineProperty(e,"__esModule",{value:!0});var a=n(2),u=r(a),f=function(t){function e(n){return i(this,e),o(this,t.call(this,String.fromCharCode(210)+n))}return s(e,t),e.prototype.valid=function(){return-1!==this.string.search(/^(\xCF*[0-9]{2}\xCF*)+$/)},e}(u["default"]);e["default"]=f},function(t,e,n){"use strict";function r(t){return t&&t.__esModule?t:{"default":t}}function i(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}function o(t,e){if(!t)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!e||"object"!=typeof e&&"function"!=typeof e?t:e}function s(t,e){if("function"!=typeof e&&null!==e)throw new TypeError("Super expression must either be null or a function, not "+typeof e);t.prototype=Object.create(e&&e.prototype,{constructor:{value:t,enumerable:!1,writable:!0,configurable:!0}}),e&&(Object.setPrototypeOf?Object.setPrototypeOf(t,e):t.__proto__=e)}function a(t){var e,n=t.match(/^[\x00-\x5F\xC8-\xCF]*/)[0].length,r=t.match(/^[\x20-\x7F\xC8-\xCF]*/)[0].length,i=t.match(/^(\xCF*[0-9]{2}\xCF*)*/)[0].length;return e=i>=2?String.fromCharCode(210)+c(t):n>r?String.fromCharCode(208)+u(t):String.fromCharCode(209)+f(t),e=e.replace(/[\xCD\xCE]([^])[\xCD\xCE]/,function(t,e){return String.fromCharCode(203)+e})}function u(t){var e=t.match(/^([\x00-\x5F\xC8-\xCF]+?)(([0-9]{2}){2,})([^0-9]|$)/);if(e)return e[1]+String.fromCharCode(204)+c(t.substring(e[1].length));var n=t.match(/^[\x00-\x5F\xC8-\xCF]+/);return n[0].length===t.length?t:n[0]+String.fromCharCode(205)+f(t.substring(n[0].length))}function f(t){var e=t.match(/^([\x20-\x7F\xC8-\xCF]+?)(([0-9]{2}){2,})([^0-9]|$)/);if(e)return e[1]+String.fromCharCode(204)+c(t.substring(e[1].length));var n=t.match(/^[\x20-\x7F\xC8-\xCF]+/);return n[0].length===t.length?t:n[0]+String.fromCharCode(206)+u(t.substring(n[0].length))}function c(t){var e=t.match(/^(\xCF*[0-9]{2}\xCF*)+/)[0],n=e.length;if(n===t.length)return t;t=t.substring(n);var r=t.match(/^[\x00-\x5F\xC8-\xCF]*/)[0].length,i=t.match(/^[\x20-\x7F\xC8-\xCF]*/)[0].length;return r>=i?e+String.fromCharCode(206)+u(t):e+String.fromCharCode(205)+f(t)}Object.defineProperty(e,"__esModule",{value:!0});var h=n(2),l=r(h),d=function(t){function e(n){i(this,e);var r=o(this,t.call(this,n));if(-1!==n.search(/^[\x00-\x7F\xC8-\xD3]+$/))var r=o(this,t.call(this,a(n)));else var r=o(this,t.call(this,n));return o(r)}return s(e,t),e}(l["default"]);e["default"]=d},function(t,e,n){"use strict";function r(t){return t&&t.__esModule?t:{"default":t}}Object.defineProperty(e,"__esModule",{value:!0}),e.CODE128C=e.CODE128B=e.CODE128A=e.CODE128=void 0;var i=n(14),o=r(i),s=n(11),a=r(s),u=n(12),f=r(u),c=n(13),h=r(c);e.CODE128=o["default"],e.CODE128A=a["default"],e.CODE128B=f["default"],e.CODE128C=h["default"]},function(t,e){"use strict";function n(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}Object.defineProperty(e,"__esModule",{value:!0});var r=function(){function t(e,r){n(this,t),this.string=e.toUpperCase(),this.mod43Enabled=r.mod43||!1,this.characters=["0","1","2","3","4","5","6","7","8","9","A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z","-","."," ","$","/","+","%","*"],this.encodings=[20957,29783,23639,30485,20951,29813,23669,20855,29789,23645,29975,23831,30533,22295,30149,24005,21623,29981,23837,22301,30023,23879,30545,22343,30161,24017,21959,30065,23921,22385,29015,18263,29141,17879,29045,18293,17783,29021,18269,17477,17489,17681,20753,35770]}return t.prototype.getEncoding=function(t){return this.getBinary(this.characterValue(t))},t.prototype.getBinary=function(t){return this.encodings[t].toString(2)},t.prototype.getCharacter=function(t){return this.characters[t]},t.prototype.characterValue=function(t){return this.characters.indexOf(t)},t.prototype.encode=function(){for(var t=this.string,e=this.getEncoding("*"),n=0;n<this.string.length;n++)e+=this.getEncoding(this.string[n])+"0";if(this.mod43Enabled){for(var r=0,n=0;n<this.string.length;n++)r+=this.characterValue(this.string[n]);r%=43,e+=this.getBinary(r)+"0",t+=this.getCharacter(r)}return e+=this.getEncoding("*"),{data:e,text:t}},t.prototype.valid=function(){return-1!==this.string.search(/^[0-9A-Z\-\.\ \$\/\+\%]+$/)},t}();e.CODE39=r},function(t,e,n){"use strict";function r(t){return t&&t.__esModule?t:{"default":t}}function i(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}Object.defineProperty(e,"__esModule",{value:!0});var o=n(0),s=r(o),a=function(){function t(e,n){i(this,t),-1!==e.search(/^[0-9]{12}$/)?this.string=e+this.checksum(e):this.string=e,this.structure=["LLLLLL","LLGLGG","LLGGLG","LLGGGL","LGLLGG","LGGLLG","LGGGLL","LGLGLG","LGLGGL","LGGLGL"],n.fontSize>10*n.width?this.fontSize=10*n.width:this.fontSize=n.fontSize,this.guardHeight=n.height+this.fontSize/2+n.textMargin,this.lastChar=n.lastChar}return t.prototype.valid=function(){return-1!==this.string.search(/^[0-9]{13}$/)&&this.string[12]==this.checksum(this.string)},t.prototype.encode=function(){var t=new s["default"],e=[],n=this.structure[this.string[0]],r=this.string.substr(1,6),i=this.string.substr(7,6);return e.push({data:"000000000000",text:this.string[0],options:{textAlign:"left",fontSize:this.fontSize}}),e.push({data:"101",options:{height:this.guardHeight}}),e.push({data:t.encode(r,n),text:r,options:{fontSize:this.fontSize}}),e.push({data:"01010",options:{height:this.guardHeight}}),e.push({data:t.encode(i,"RRRRRR"),text:i,options:{fontSize:this.fontSize}}),e.push({data:"101",options:{height:this.guardHeight}}),this.lastChar&&(e.push({data:"00"}),e.push({data:"00000",text:this.lastChar,options:{fontSize:this.fontSize}})),e},t.prototype.checksum=function(t){var e,n=0;for(e=0;12>e;e+=2)n+=parseInt(t[e]);for(e=1;12>e;e+=2)n+=3*parseInt(t[e]);return(10-n%10)%10},t}();e["default"]=a},function(t,e,n){"use strict";function r(t){return t&&t.__esModule?t:{"default":t}}function i(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}Object.defineProperty(e,"__esModule",{value:!0});var o=n(0),s=r(o),a=function(){function t(e){i(this,t),this.string=e,this.structure=["LL","LG","GL","GG"]}return t.prototype.valid=function(){return-1!==this.string.search(/^[0-9]{2}$/)},t.prototype.encode=function(){var t=new s["default"],e=this.structure[parseInt(this.string)%4],n="1011";return n+=t.encode(this.string,e,"01"),{data:n,text:this.string}},t}();e["default"]=a},function(t,e,n){"use strict";function r(t){return t&&t.__esModule?t:{"default":t}}function i(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}Object.defineProperty(e,"__esModule",{value:!0});var o=n(0),s=r(o),a=function(){function t(e){i(this,t),this.string=e,this.structure=["GGLLL","GLGLL","GLLGL","GLLLG","LGGLL","LLGGL","LLLGG","LGLGL","LGLLG","LLGLG"]}return t.prototype.valid=function(){return-1!==this.string.search(/^[0-9]{5}$/)},t.prototype.encode=function(){var t=new s["default"],e=this.checksum(),n="1011";return n+=t.encode(this.string,this.structure[e],"01"),{data:n,text:this.string}},t.prototype.checksum=function(){var t=0;return t+=3*parseInt(this.string[0]),t+=9*parseInt(this.string[1]),t+=3*parseInt(this.string[2]),t+=9*parseInt(this.string[3]),t+=3*parseInt(this.string[4]),t%10},t}();e["default"]=a},function(t,e,n){"use strict";function r(t){return t&&t.__esModule?t:{"default":t}}function i(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}Object.defineProperty(e,"__esModule",{value:!0});var o=n(0),s=r(o),a=function(){function t(e){i(this,t),-1!==e.search(/^[0-9]{7}$/)?this.string=e+this.checksum(e):this.string=e}return t.prototype.valid=function(){return-1!==this.string.search(/^[0-9]{8}$/)&&this.string[7]==this.checksum(this.string)},t.prototype.encode=function(){var t=new s["default"],e="",n=this.string.substr(0,4),r=this.string.substr(4,4);return e+=t.startBin,e+=t.encode(n,"LLLL"),e+=t.middleBin,e+=t.encode(r,"RRRR"),e+=t.endBin,{data:e,text:this.string}},t.prototype.checksum=function(t){var e,n=0;for(e=0;7>e;e+=2)n+=3*parseInt(t[e]);for(e=1;7>e;e+=2)n+=parseInt(t[e]);return(10-n%10)%10},t}();e["default"]=a},function(t,e,n){"use strict";function r(t){return t&&t.__esModule?t:{"default":t}}function i(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}Object.defineProperty(e,"__esModule",{value:!0});var o=n(0),s=r(o),a=function(){function t(e,n){i(this,t),-1!==e.search(/^[0-9]{11}$/)?this.string=e+this.checksum(e):this.string=e,n.fontSize>10*n.width?this.fontSize=10*n.width:this.fontSize=n.fontSize,this.guardHeight=n.height+this.fontSize/2+n.textMargin}return t.prototype.valid=function(){return-1!==this.string.search(/^[0-9]{12}$/)&&this.string[11]==this.checksum(this.string)},t.prototype.encode=function(){var t=new s["default"],e=[];return e.push({data:"00000000",text:this.string[0],options:{textAlign:"left",fontSize:this.fontSize}}),e.push({data:"101"+t.encode(this.string[0],"L"),options:{height:this.guardHeight}}),e.push({data:t.encode(this.string.substr(1,5),"LLLLL"),text:this.string.substr(1,5),options:{fontSize:this.fontSize}}),e.push({data:"01010",options:{height:this.guardHeight}}),e.push({data:t.encode(this.string.substr(6,5),"RRRRR"),text:this.string.substr(6,5),options:{fontSize:this.fontSize}}),e.push({data:t.encode(this.string[11],"R")+"101",options:{height:this.guardHeight}}),e.push({data:"00000000",text:this.string[11],options:{textAlign:"right",fontSize:this.fontSize}}),e},t.prototype.checksum=function(t){var e,n=0;for(e=1;11>e;e+=2)n+=parseInt(t[e]);for(e=0;11>e;e+=2)n+=3*parseInt(t[e]);return(10-n%10)%10},t}();e["default"]=a},function(t,e,n){"use strict";function r(t){return t&&t.__esModule?t:{"default":t}}Object.defineProperty(e,"__esModule",{value:!0}),e.UPC=e.EAN2=e.EAN5=e.EAN8=e.EAN13=void 0;var i=n(17),o=r(i),s=n(20),a=r(s),u=n(19),f=r(u),c=n(18),h=r(c),l=n(21),d=r(l);e.EAN13=o["default"],e.EAN8=a["default"],e.EAN5=f["default"],e.EAN2=h["default"],e.UPC=d["default"]},function(t,e){"use strict";function n(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}Object.defineProperty(e,"__esModule",{value:!0});var r=function(){function t(e){n(this,t),this.string=e}return t.prototype.encode=function(){return{data:"10101010101010101010101010101010101010101",text:this.string}},t.prototype.valid=function(){return!0},t}();e.GenericBarcode=r},function(t,e){"use strict";function n(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}Object.defineProperty(e,"__esModule",{value:!0});var r=function(){function t(e){n(this,t),this.string=e,this.binaryRepresentation={0:"00110",1:"10001",2:"01001",3:"11000",4:"00101",5:"10100",6:"01100",7:"00011",8:"10010",9:"01010"}}return t.prototype.valid=function(){return-1!==this.string.search(/^([0-9]{2})+$/)},t.prototype.encode=function(){for(var t="1010",e=0;e<this.string.length;e+=2)t+=this.calculatePair(this.string.substr(e,2));return t+="11101",{data:t,text:this.string}},t.prototype.calculatePair=function(t){for(var e="",n=this.binaryRepresentation[t[0]],r=this.binaryRepresentation[t[1]],i=0;5>i;i++)e+="1"==n[i]?"111":"1",e+="1"==r[i]?"000":"0";return e},t}();e.ITF=r},function(t,e){"use strict";function n(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}Object.defineProperty(e,"__esModule",{value:!0});var r=function(){function t(e){n(this,t),this.string=e,-1!==e.search(/^[0-9]{13}$/)&&(this.string+=this.checksum(e)),this.binaryRepresentation={0:"00110",1:"10001",2:"01001",3:"11000",4:"00101",5:"10100",6:"01100",7:"00011",8:"10010",9:"01010"}}return t.prototype.valid=function(){return-1!==this.string.search(/^[0-9]{14}$/)&&this.string[13]==this.checksum()},t.prototype.encode=function(){for(var t="1010",e=0;14>e;e+=2)t+=this.calculatePair(this.string.substr(e,2));return t+="11101",{data:t,text:this.string}},t.prototype.calculatePair=function(t){for(var e="",n=this.binaryRepresentation[t[0]],r=this.binaryRepresentation[t[1]],i=0;5>i;i++)e+="1"==n[i]?"111":"1",e+="1"==r[i]?"000":"0";return e},t.prototype.checksum=function(){for(var t=0,e=0;13>e;e++)t+=parseInt(this.string[e])*(3-e%2*2);return 10-t%10},t}();e.ITF14=r},function(t,e,n){"use strict";function r(t){return t&&t.__esModule?t:{"default":t}}function i(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}function o(t,e){if(!t)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!e||"object"!=typeof e&&"function"!=typeof e?t:e}function s(t,e){if("function"!=typeof e&&null!==e)throw new TypeError("Super expression must either be null or a function, not "+typeof e);t.prototype=Object.create(e&&e.prototype,{constructor:{value:t,enumerable:!1,writable:!0,configurable:!0}}),e&&(Object.setPrototypeOf?Object.setPrototypeOf(t,e):t.__proto__=e)}Object.defineProperty(e,"__esModule",{value:!0});var a=n(1),u=r(a),f=n(3),c=function(t){function e(n){i(this,e);var r=o(this,t.call(this,n));return r.string+=(0,f.mod10)(r.string),r}return s(e,t),e}(u["default"]);e["default"]=c},function(t,e,n){"use strict";function r(t){return t&&t.__esModule?t:{"default":t}}function i(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}function o(t,e){if(!t)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!e||"object"!=typeof e&&"function"!=typeof e?t:e}function s(t,e){if("function"!=typeof e&&null!==e)throw new TypeError("Super expression must either be null or a function, not "+typeof e);t.prototype=Object.create(e&&e.prototype,{constructor:{value:t,enumerable:!1,writable:!0,configurable:!0}}),e&&(Object.setPrototypeOf?Object.setPrototypeOf(t,e):t.__proto__=e)}Object.defineProperty(e,"__esModule",{value:!0});var a=n(1),u=r(a),f=n(3),c=function(t){function e(n){i(this,e);var r=o(this,t.call(this,n));return r.string+=(0,f.mod10)(r.string),r.string+=(0,f.mod10)(r.string),r}return s(e,t),e}(u["default"]);e["default"]=c},function(t,e,n){"use strict";function r(t){return t&&t.__esModule?t:{"default":t}}function i(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}function o(t,e){if(!t)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!e||"object"!=typeof e&&"function"!=typeof e?t:e}function s(t,e){if("function"!=typeof e&&null!==e)throw new TypeError("Super expression must either be null or a function, not "+typeof e);t.prototype=Object.create(e&&e.prototype,{constructor:{value:t,enumerable:!1,writable:!0,configurable:!0}}),e&&(Object.setPrototypeOf?Object.setPrototypeOf(t,e):t.__proto__=e)}Object.defineProperty(e,"__esModule",{value:!0});var a=n(1),u=r(a),f=n(3),c=function(t){function e(n){i(this,e);var r=o(this,t.call(this,n));return r.string+=(0,f.mod11)(r.string),r}return s(e,t),e}(u["default"]);e["default"]=c},function(t,e,n){"use strict";function r(t){return t&&t.__esModule?t:{"default":t}}function i(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}function o(t,e){if(!t)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!e||"object"!=typeof e&&"function"!=typeof e?t:e}function s(t,e){if("function"!=typeof e&&null!==e)throw new TypeError("Super expression must either be null or a function, not "+typeof e);t.prototype=Object.create(e&&e.prototype,{constructor:{value:t,enumerable:!1,writable:!0,configurable:!0}}),e&&(Object.setPrototypeOf?Object.setPrototypeOf(t,e):t.__proto__=e)}Object.defineProperty(e,"__esModule",{value:!0});var a=n(1),u=r(a),f=n(3),c=function(t){function e(n){i(this,e);var r=o(this,t.call(this,n));return r.string+=(0,f.mod11)(r.string),r.string+=(0,f.mod10)(r.string),r}return s(e,t),e}(u["default"]);e["default"]=c},function(t,e,n){"use strict";function r(t){return t&&t.__esModule?t:{"default":t}}Object.defineProperty(e,"__esModule",{value:!0}),e.MSI1110=e.MSI1010=e.MSI11=e.MSI10=e.MSI=void 0;var i=n(1),o=r(i),s=n(26),a=r(s),u=n(28),f=r(u),c=n(27),h=r(c),l=n(29),d=r(l);e.MSI=o["default"],e.MSI10=a["default"],e.MSI11=f["default"],e.MSI1010=h["default"],e.MSI1110=d["default"]},function(t,e){"use strict";function n(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}Object.defineProperty(e,"__esModule",{value:!0});var r=function(){function t(e){n(this,t),this.number=parseInt(e,10)}return t.prototype.encode=function(){for(var t=this.number,e="";!isNaN(t)&&0!=t;)t%2===0?(e="11100"+e,t=(t-2)/2):(e="100"+e,t=(t-1)/2);return e=e.slice(0,-2),{data:e,text:this.number+""}},t.prototype.valid=function(){return this.number>=3&&this.number<=131070},t}();e.pharmacode=r},function(t,e){"use strict";function n(t){var e=["width","height","textMargin","fontSize","margin","marginLeft","marginBottom","marginLeft","marginRight"];for(var n in e)n=e[n],"string"==typeof t[n]&&(t[n]=parseInt(t[n],10));return"string"==typeof t.displayValue&&(t.displayValue="false"!=t.displayValue),t}Object.defineProperty(e,"__esModule",{value:!0}),e["default"]=n},function(t,e,n){"use strict";function r(t){return t&&t.__esModule?t:{"default":t}}function i(t,e,n){if(!t.getContext)throw new Error("The browser does not support canvas.");o(t,n,e);for(var r=0;r<e.length;r++){var i=(0,h["default"])(n,e[r].options);s(t,i,e[r]),a(t,i,e[r]),u(t,e[r])}f(t)}function o(t,e,n){var r=t.getContext("2d");r.save();for(var i=0,o=0,s=0;s<n.length;s++){var a=(0,h["default"])(a,n[s].options);r.font=a.fontOptions+" "+a.fontSize+"px "+a.font;var u=r.measureText(n[s].text).width,f=n[s].data.length*a.width;n[s].width=Math.ceil(Math.max(u,f));var c=a.height+(a.displayValue&&n[s].text.length>0?a.fontSize:0)+a.textMargin+a.marginTop+a.marginBottom,l=0;a.displayValue&&u>f&&("center"==a.textAlign?l=Math.floor((u-f)/2):"left"==a.textAlign?l=0:"right"==a.textAlign&&(l=Math.floor(u-f))),n[s].barcodePadding=l,c>o&&(o=c),i+=n[s].width}t.width=i+e.marginLeft+e.marginRight,t.height=o,r.clearRect(0,0,t.width,t.height),e.background&&(r.fillStyle=e.background,r.fillRect(0,0,t.width,t.height)),r.translate(e.marginLeft,0)}function s(t,e,n){var r,i,o=t.getContext("2d"),s=n.data;r="top"==e.textPosition?e.marginTop+e.fontSize+e.textMargin:e.marginTop,i=e.height,o.fillStyle=e.lineColor;for(var a=0;a<s.length;a++){var u=a*e.width+n.barcodePadding;"1"===s[a]?o.fillRect(u,r,e.width,e.height):s[a]&&o.fillRect(u,r,e.width,e.height*s[a])}}function a(t,e,n){var r=t.getContext("2d"),i=e.fontOptions+" "+e.fontSize+"px "+e.font;if(e.displayValue){var o,s;s="top"==e.textPosition?e.marginTop+e.fontSize-e.textMargin:e.height+e.textMargin+e.marginTop+e.fontSize,r.font=i,"left"==e.textAlign||n.barcodePadding>0?(o=0,r.textAlign="left"):"right"==e.textAlign?(o=n.width-1,r.textAlign="right"):(o=n.width/2,r.textAlign="center"),r.fillText(n.text,o,s)}}function u(t,e){var n=t.getContext("2d");n.translate(e.width,0)}function f(t){var e=t.getContext("2d");e.restore()}Object.defineProperty(e,"__esModule",{value:!0});var c=n(4),h=r(c);e["default"]=i},function(t,e,n){"use strict";function r(t){return t&&t.__esModule?t:{"default":t}}function i(t,e,n){var r=n.marginLeft;o(t,n,e);for(var i=0;i<e.length;i++){var u=(0,d["default"])(n,e[i].options),h=f(r,u.marginTop,t);c(h,u,e[i]),s(h,u,e[i]),a(h,u,e[i]),r+=e[i].width}}function o(t,e,n){for(;t.firstChild;)t.removeChild(t.firstChild);for(var r=0,i=0,o=0;o<n.length;o++){var s=(0,d["default"])(s,n[o].options),a=u(n[o].text,t,s),f=n[o].data.length*s.width;n[o].width=Math.ceil(Math.max(a,f));var c=s.height+(s.displayValue&&n[o].text.length>0?s.fontSize:0)+s.textMargin+s.marginTop+s.marginBottom,h=0;
s.displayValue&&a>f&&("center"==s.textAlign?h=Math.floor((a-f)/2):"left"==s.textAlign?h=0:"right"==s.textAlign&&(h=Math.floor(a-f))),n[o].barcodePadding=h,c>i&&(i=c),r+=n[o].width}var l=r+e.marginLeft+e.marginRight,g=i;t.setAttribute("width",l+"px"),t.setAttribute("height",g+"px"),t.setAttribute("x","0px"),t.setAttribute("y","0px"),t.setAttribute("viewBox","0 0 "+l+" "+g),t.setAttribute("xmlns",p),t.setAttribute("version","1.1"),e.background&&(t.style.background=e.background)}function s(t,e,n){var r,i,o=n.data;r="top"==e.textPosition?e.fontSize+e.textMargin:0,i=e.height;for(var s=0,a=0;a<o.length;a++){var u=a*e.width+n.barcodePadding;"1"===o[a]?s++:s>0&&(h(u-e.width*s,r,e.width*s,e.height,t),s=0)}s>0&&h(u-e.width*(s-1),r,e.width*s,e.height,t)}function a(t,e,n){var r=document.createElementNS(p,"text");if(e.displayValue){var i,o;r.setAttribute("style","font:"+e.fontOptions+" "+e.fontSize+"px "+e.font),o="top"==e.textPosition?e.fontSize-e.textMargin:e.height+e.textMargin+e.fontSize,"left"==e.textAlign||n.barcodePadding>0?(i=0,r.setAttribute("text-anchor","start")):"right"==e.textAlign?(i=n.width-1,r.setAttribute("text-anchor","end")):(i=n.width/2,r.setAttribute("text-anchor","middle")),r.setAttribute("x",i),r.setAttribute("y",o),r.appendChild(document.createTextNode(n.text)),t.appendChild(r)}}function u(t,e,n){var r=document.createElement("canvas").getContext("2d");r.font=n.fontOptions+" "+n.fontSize+"px "+n.font;var i=r.measureText(t).width;return i}function f(t,e,n){var r=document.createElementNS(p,"g");return r.setAttribute("transform","translate("+t+", "+e+")"),n.appendChild(r),r}function c(t,e,n){t.setAttribute("style","fill:"+e.lineColor+";")}function h(t,e,n,r,i){var o=document.createElementNS(p,"rect");o.setAttribute("x",t),o.setAttribute("y",e),o.setAttribute("width",n),o.setAttribute("height",r),i.appendChild(o)}Object.defineProperty(e,"__esModule",{value:!0});var l=n(4),d=r(l);e["default"]=i;var p="http://www.w3.org/2000/svg"}]);
	]]>
	</script>
	</head>
	<body>
			<div class="documentContainerOuter">
				<div class="documentContainer">
	<xsl:for-each select="$XML">
						<div id="ustBolum">
									<div id="b1" class="box"> 
										<div id="AccountingSupplierParty" class="gonderici kutu">
																	<xsl:for-each select="n1:Invoice">
									<xsl:for-each select="cac:AccountingSupplierParty">
									<xsl:for-each select="cac:Party">
									<div class="partyName">
									<xsl:if test="not(cac:Person/cbc:FirstName ='') or not(cac:Person/cbc:FamilyName ='')">
										<xsl:for-each select="cac:Person">
										<xsl:for-each select="cbc:Title">
										<xsl:apply-templates/>
										<span>
										<xsl:text>&#160;</xsl:text>
										</span>
										</xsl:for-each>
										<xsl:for-each select="cbc:FirstName">
										<xsl:apply-templates/>
										<span>
										<xsl:text>&#160;</xsl:text>
										</span>
										</xsl:for-each>
										<xsl:for-each select="cbc:MiddleName">
										<xsl:apply-templates/>
										<span>
										<xsl:text>&#160;</xsl:text>
										</span>
										</xsl:for-each>
										<xsl:for-each select="cbc:FamilyName">
										<xsl:apply-templates/>
										<span>
										<xsl:text>&#160;</xsl:text>
										</span>
										</xsl:for-each>
										<xsl:for-each select="cbc:NameSuffix">
										<xsl:apply-templates/>
										</xsl:for-each>
										</xsl:for-each>
										<br/>
									</xsl:if>
									<xsl:if test="not(cac:PartyName/cbc:Name ='')">
										<xsl:value-of select="cac:PartyName/cbc:Name"/>
									</xsl:if>
									</div>
									</xsl:for-each>
									</xsl:for-each>
									</xsl:for-each>
									
									<xsl:for-each select="n1:Invoice">
									<xsl:for-each select="cac:AccountingSupplierParty">
									<xsl:for-each select="cac:Party">
									<div class="addres">
									<xsl:for-each select="cac:PostalAddress">
									<xsl:for-each select="cbc:Region">
									<xsl:apply-templates/>
									<span>
									<xsl:text>&#160;</xsl:text>
									</span>
									</xsl:for-each>
									<xsl:for-each select="cbc:StreetName">
									<xsl:apply-templates/>
									<span>
									<xsl:text>&#160;</xsl:text>
									</span>
									</xsl:for-each>
									<xsl:for-each select="cbc:BuildingName">
									<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:if test="cbc:BuildingNumber">
									<span>
									<xsl:text> No:</xsl:text>
									</span>
									<xsl:for-each select="cbc:BuildingNumber">
									<xsl:apply-templates/>
									</xsl:for-each>
									<span>
									<xsl:text>&#160;</xsl:text>
									</span>
									</xsl:if>
									<xsl:for-each select="cbc:Room">
									<span>
									<xsl:text>Kapı No:</xsl:text>
									</span>
									<xsl:apply-templates/>
									<span>
									<xsl:text>&#160;</xsl:text>
									</span>
									</xsl:for-each>

									<xsl:if test="cbc:District !=''">
									<xsl:for-each select="cbc:District">
									<xsl:apply-templates/>
									<span>
									<xsl:text>&#160;</xsl:text>
									</span>
									</xsl:for-each>
									<br/>
									</xsl:if>
									
									<xsl:if test="cbc:PostalZone != '' ">
										<xsl:for-each select="cbc:PostalZone">
										<xsl:apply-templates/>
										<span>
										<xsl:text>&#160;</xsl:text>
										</span>
										</xsl:for-each>
									</xsl:if>
									<xsl:for-each select="cbc:CitySubdivisionName">
									<xsl:apply-templates/>
									</xsl:for-each>
									<span>
									<xsl:text> / </xsl:text>
									</span>
									<xsl:for-each select="cbc:CityName">
									<xsl:apply-templates/>
									</xsl:for-each>
									</xsl:for-each>
									</div>
									</xsl:for-each>
									</xsl:for-each>
									</xsl:for-each>
									
									<xsl:for-each select="n1:Invoice">
									<xsl:for-each select="cac:AccountingSupplierParty">
									<xsl:for-each select="cac:Party">
									<div class="telFax">
									<xsl:for-each select="cac:Contact">
									<xsl:if test="cbc:Telephone !=''">
									<span>
									<xsl:text>Tel: </xsl:text>
									</span>
									<xsl:for-each select="cbc:Telephone">
									<xsl:apply-templates/>
									</xsl:for-each>
									</xsl:if>
									<xsl:if test="cbc:Telefax !=''">
									<span>
									<xsl:text> Faks: </xsl:text>
									</span>
									<xsl:for-each select="cbc:Telefax">
									<xsl:apply-templates/>
									</xsl:for-each>
									</xsl:if>
									<span>
									<xsl:text>&#160;</xsl:text>
									</span>
									</xsl:for-each>
									</div>
									</xsl:for-each>
									</xsl:for-each>
									</xsl:for-each>
									
								<xsl:for-each
									select="//n1:Invoice/cac:AccountingSupplierParty/cac:Party/cbc:WebsiteURI">
									<div class="WebsiteURI">
									<xsl:text>Web Sitesi: </xsl:text>
									<xsl:value-of select="."/>
									</div>
								</xsl:for-each>
								
								<xsl:for-each
									select="//n1:Invoice/cac:AccountingSupplierParty/cac:Party/cac:Contact/cbc:ElectronicMail">
									<div class="eMail">
									<xsl:text>e-Posta: </xsl:text>
									<xsl:value-of select="."/>
									</div>
								</xsl:for-each>
								
									<div class="taxOffice">
										<xsl:text>Vergi Dairesi: </xsl:text>
										<xsl:value-of
										select="//n1:Invoice/cac:AccountingSupplierParty/cac:Party/cac:PartyTaxScheme/cac:TaxScheme/cbc:Name"
										/>
									</div>
									
								<xsl:for-each
								select="//n1:Invoice/cac:AccountingSupplierParty/cac:Party/cac:PartyIdentification/cbc:ID">
								<xsl:if test="@schemeID != 'MUSTERINO'">
								<div class="partyID">
									<xsl:choose>
										<xsl:when test="@schemeID = 'TICARETSICILNO'">
											<xsl:text>Ticaret Sicil No</xsl:text>
										</xsl:when>
										<xsl:when test="@schemeID = 'MERSISNO'">
											<xsl:text>MERSİS No</xsl:text>
										</xsl:when>
										<xsl:otherwise>
											<xsl:value-of select="@schemeID"/>
										</xsl:otherwise>
									</xsl:choose>
									<xsl:text>: </xsl:text>
									<xsl:value-of select="."/>
								</div>
								</xsl:if>
								</xsl:for-each>
								
								

						</div>
						
						<div class="alici kutu">
														<div class="customerTitle">
									<xsl:text>SAYIN</xsl:text>
								</div>
								
								<div class="partyName">
									<xsl:for-each select="n1:Invoice">
									<xsl:for-each select="cac:AccountingCustomerParty">
									<xsl:for-each select="cac:Party">
									<div class="partyName">
									<xsl:if test="not(cac:Person/cbc:FirstName ='') or not(cac:Person/cbc:FamilyName ='')">
										<xsl:for-each select="cac:Person">
										<xsl:for-each select="cbc:Title">
										<xsl:apply-templates/>
										<span>
										<xsl:text>&#160;</xsl:text>
										</span>
										</xsl:for-each>
										<xsl:for-each select="cbc:FirstName">
										<xsl:apply-templates/>
										<span>
										<xsl:text>&#160;</xsl:text>
										</span>
										</xsl:for-each>
										<xsl:for-each select="cbc:MiddleName">
										<xsl:apply-templates/>
										<span>
										<xsl:text>&#160;</xsl:text>
										</span>
										</xsl:for-each>
										<xsl:for-each select="cbc:FamilyName">
										<xsl:apply-templates/>
										<span>
										<xsl:text>&#160;</xsl:text>
										</span>
										</xsl:for-each>
										<xsl:for-each select="cbc:NameSuffix">
										<xsl:apply-templates/>
										</xsl:for-each>
										</xsl:for-each>
										<br/>
									</xsl:if>
									<xsl:if test="not(cac:PartyName/cbc:Name ='')">
										<xsl:value-of select="cac:PartyName/cbc:Name"/>
									</xsl:if>
									</div>
									</xsl:for-each>
									</xsl:for-each>
									</xsl:for-each>
								</div>	
								
								<div class="addres">
									<xsl:for-each select="n1:Invoice">
									<xsl:for-each select="cac:AccountingCustomerParty">
									<xsl:for-each select="cac:Party">
									<xsl:for-each select="cac:PostalAddress">
									<xsl:for-each select="cbc:Region">
									<xsl:apply-templates/>
									<span>
									<xsl:text>&#160;</xsl:text>
									</span>
									</xsl:for-each>
									<xsl:if test="cbc:StreetName !=''">
									<xsl:for-each select="cbc:StreetName">
									<xsl:apply-templates/>
									<span>
									<xsl:text>&#160;</xsl:text>
									</span>
									</xsl:for-each>
									</xsl:if>

									<xsl:for-each select="cbc:BuildingName">
									<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:if test="cbc:BuildingNumber !=''">
									<xsl:for-each select="cbc:BuildingNumber">
									<span>
									<xsl:text> No:</xsl:text>
									</span>
									<xsl:apply-templates/>
									<span>
									<xsl:text>&#160;</xsl:text>
									</span>
									</xsl:for-each>
									<br/>
									</xsl:if>

									<xsl:if test="cbc:Room !=''">
									<xsl:for-each select="cbc:Room">
									<span>
									<xsl:text>Kapı No:</xsl:text>
									</span>
									<xsl:apply-templates/>
									<span>
									<xsl:text>&#160;</xsl:text>
									</span>
									</xsl:for-each>
									<br/>
									</xsl:if>

									<xsl:if test="cbc:District !=''">
									<xsl:for-each select="cbc:District">
									<xsl:apply-templates/>
									<span>
									<xsl:text>&#160;</xsl:text>
									</span>
									</xsl:for-each>
									<br/>
									</xsl:if>

									<xsl:if test="cbc:PostalZone != '' ">
										<xsl:for-each select="cbc:PostalZone">
										<xsl:apply-templates/>
										<span>
										<xsl:text>&#160;</xsl:text>
										</span>
										</xsl:for-each>
									</xsl:if>
									<xsl:if test="cbc:CitySubdivisionName != '' ">
									<xsl:for-each select="cbc:CitySubdivisionName">
									<xsl:apply-templates/>
									<span>
									<xsl:text>/ </xsl:text>
									</span>
									</xsl:for-each>
									</xsl:if>
									
									<xsl:if test="cbc:CityName != ''">
									<xsl:for-each select="cbc:CityName">
									<xsl:apply-templates/>
									<span>
									<xsl:text>&#160;</xsl:text>
									</span>
									</xsl:for-each>
									</xsl:if>
									</xsl:for-each>

									</xsl:for-each>
									</xsl:for-each>
									</xsl:for-each>
								</div> 
								
<xsl:if test="//n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:Contact/cbc:Telephone !='' or //n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:Contact/cbc:Telefax !=''">
									<xsl:for-each select="n1:Invoice">
									<xsl:for-each select="cac:AccountingCustomerParty">
									<xsl:for-each select="cac:Party">
									<div class="telFax">
									<xsl:for-each select="cac:Contact">
									<xsl:if test="cbc:Telephone !=''">
									<span>
									<xsl:text>Tel: </xsl:text>
									</span>
									<xsl:for-each select="cbc:Telephone">
									<xsl:apply-templates/>
									</xsl:for-each>
									</xsl:if>
									<xsl:if test="cbc:Telefax !=''">
									<span>
									<xsl:text> Faks: </xsl:text>
									</span>
									<xsl:for-each select="cbc:Telefax">
									<xsl:apply-templates/>
									</xsl:for-each>
									</xsl:if>
									<span>
									<xsl:text>&#160;</xsl:text>
									</span>
									</xsl:for-each>
									</div>
									</xsl:for-each>
									</xsl:for-each>
									</xsl:for-each>
									
</xsl:if> 
<xsl:if test="//n1:Invoice/cac:AccountingCustomerParty/cac:Party/cbc:WebsiteURI != ''">
								<xsl:for-each
								select="//n1:Invoice/cac:AccountingCustomerParty/cac:Party/cbc:WebsiteURI">
								<div class="WebsiteURI">
									<xsl:text>Web Sitesi: </xsl:text>
									<xsl:value-of select="."/>
								</div>
								</xsl:for-each>
								
</xsl:if> 
<xsl:if test="//n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:Contact/cbc:ElectronicMail != ''">
								<xsl:for-each
								select="//n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:Contact/cbc:ElectronicMail">
								<div class="eMail">
									<xsl:text>e-Posta: </xsl:text>
									<xsl:value-of select="."/>
								</div>
								</xsl:for-each>
								
</xsl:if> 
									<div class="taxOffice">
										<xsl:text>Vergi Dairesi: </xsl:text>
										<xsl:value-of
										select="//n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:PartyTaxScheme/cac:TaxScheme/cbc:Name"
										/>
									</div>
									
								<xsl:for-each
								select="//n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:PartyIdentification">
								<div class="partyID">
									<xsl:choose>
										<xsl:when test="cbc:ID/@schemeID = 'TICARETSICILNO'">
											<xsl:text>Ticaret Sicil No</xsl:text>
										</xsl:when>
										<xsl:when test="cbc:ID/@schemeID = 'MERSISNO'">
											<xsl:text>MERSİS No</xsl:text>
										</xsl:when>
										<xsl:otherwise>
											<xsl:value-of select="cbc:ID/@schemeID"/>
										</xsl:otherwise>
									</xsl:choose>
									<xsl:text>: </xsl:text>
									<xsl:value-of select="cbc:ID"/>
								</div>
								</xsl:for-each>
								

						</div>
    <div id="ETTN"> 
						<span style="font-weight:bold; ">
							<xsl:text>ETTN: </xsl:text>
						</span>
						<xsl:for-each select="n1:Invoice">
							<xsl:for-each select="cbc:UUID">
							<xsl:apply-templates/>
							</xsl:for-each>
						</xsl:for-each>
		</div> 
		<div>
				<br/>
				 		<b><xsl:text>Kargo Adı:</xsl:text> </b>  
						<xsl:variable name="note" select="//n1:Invoice/cbc:Note"/>		
						<xsl:value-of select="substring-after($note[contains(.,'##internetSatis_gonderiTasiyanAd#Gönderi Taşıyan Kişi Ad:')],'##internetSatis_gonderiTasiyanAd#Gönderi Taşıyan Kişi Ad:')" />	
                    <br/><br/>
<xsl:for-each select="//n1:Invoice/cac:AdditionalDocumentReference">
	<xsl:if test="contains(cbc:DocumentType,'Barkod')">
		<xsl:variable name="Barkod" select="./cac:Attachment/cbc:EmbeddedDocumentBinaryObject"/> 
		<img align="left" alt="Barkod" style="width:300px;height:140"	src="data:image/jpeg;base64,{$Barkod}"/>	
	</xsl:if>	
</xsl:for-each>
	
				  <br/><br/><br/><br/><br/><br/><br/>
                    		<b><xsl:text>Sevk Adresi: </xsl:text></b>  
							
							<xsl:variable name="note2" select="//n1:Invoice/cbc:Note"/>		
						<xsl:value-of select="substring-after($note2[contains(.,'Delivery;')],'Delivery;')" />	
                     <br/>
		</div>

								

				</div> 
<div id="b2" class="box"> 
						
								<div class="ph empty ph6">
								<xsl:text disable-output-escaping="yes"><![CDATA[<div><img style="display: block; margin-left: auto; margin-right: auto;" src="data:image/jpeg;base64,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" alt="e-Arşiv Fatura Logo" width="86" height="84" align="middle"/></div>
<div style="text-align: center;"><span style="font-size: 11pt; font-weight: bold;">e-Arşiv Fatura<br/><br/><img src="data:image/png;base64,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" alt="" width="60" height="105"/><br/><br/><br/></span></div>
]]></xsl:text>
								</div>

</div> 
	<div id="b3" class="box">
		<div id="qrcode"/>

	<div id="qrvalue" style="visibility: hidden; position:absolute;">
{"vkntckn":"<xsl:value-of select="n1:Invoice/cac:AccountingSupplierParty/cac:Party/cac:PartyIdentification/cbc:ID[@schemeID='TCKN' or @schemeID='VKN']"/>",
"avkntckn":"<xsl:value-of select="n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:PartyIdentification/cbc:ID[@schemeID='TCKN' or @schemeID='VKN']"/>",
"senaryo":"<xsl:value-of select="n1:Invoice/cbc:ProfileID"/>",
"tip":"<xsl:value-of select="n1:Invoice/cbc:InvoiceTypeCode"/>",
"tarih":"<xsl:value-of select="n1:Invoice/cbc:IssueDate"/>",
"no":"<xsl:value-of select="n1:Invoice/cbc:ID"/>",
"ettn":"<xsl:value-of select="n1:Invoice/cbc:UUID"/>",
"paraBirimi":"<xsl:value-of select="n1:Invoice/cbc:DocumentCurrencyCode"/>",
"malhizmettoplam":"<xsl:value-of select="n1:Invoice/cac:LegalMonetaryTotal/cbc:LineExtensionAmount"/>",<xsl:for-each select="n1:Invoice/cac:TaxTotal/cac:TaxSubtotal[cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode = '0015']">
"kdvmatrah(<xsl:value-of select="cbc:Percent"/>)":"<xsl:value-of select="(./cbc:TaxableAmount[../cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode='0015'])"/>",</xsl:for-each>
		<xsl:for-each select="n1:Invoice/cac:TaxTotal/cac:TaxSubtotal[cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode = '0015']">        
"hesaplanankdv(<xsl:value-of select="cbc:Percent"/>)":"<xsl:for-each select="cac:TaxCategory/cac:TaxScheme">
				<xsl:value-of select="(../../cbc:TaxAmount)"/>", </xsl:for-each>
		</xsl:for-each>             
"vergidahil":"<xsl:value-of select="n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount"/>",
"odenecek":"<xsl:value-of select="n1:Invoice/cac:LegalMonetaryTotal/cbc:PayableAmount"/>"}
	</div>
	<script type="text/javascript">
										var qrcode = new QRCode(document.getElementById("qrcode"), {
										width : 150,
										height : 150,
										correctLevel : QRCode.CorrectLevel.M
										});

										function makeCode (msg) {		
										var elText = document.getElementById("text");

										qrcode.makeCode(msg);
										}

										makeCode(document.getElementById("qrvalue").innerHTML);
	</script>
<br/><br/>
	<div id="despatchTable">
				<div class="ph empty ph7">
	<xsl:text disable-output-escaping="yes"><![CDATA[<div style="text-align: left;"><img src="data:image/png;base64,
/9j/4AAQSkZJRgABAQEBLAEsAAD/4RDsRXhpZgAATU0AKgAAAAgABQESAAMAAAABAAEAAAE7AAIAAAAHAAAIVodpAAQAAAABAAAIXpydAAEAAAAOAAAQ1uocAAcAAAgMAAAASgAAAAAc6gAAAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAE1PREEwNAAAAAWQAwACAAAAFAAAEKyQBAACAAAAFAAAEMCSkQACAAAAAzc0AACSkgACAAAAAzc0AADqHAAHAAAIDAAACKAAAAAAHOoAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA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b3JnL2RjL2VsZW1lbnRzLzEuMS8iPjxkYzpjcmVhdG9yPjxyZGY6U2VxIHhtbG5zOnJkZj0iaHR0cDovL3d3dy53My5vcmcvMTk5OS8wMi8yMi1yZGYtc3ludGF4LW5zIyI+PHJkZjpsaT5NT0RBMDQ8L3JkZjpsaT48L3JkZjpTZXE+DQoJCQk8L2RjOmNyZWF0b3I+PC9yZGY6RGVzY3JpcHRpb24+PC9yZGY6UkRGPjwveDp4bXBtZXRhPg0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgCiAgICAgICAgICAgICAgICAgICAgICAgICAgICA8P3hwYWNrZXQgZW5kPSd3Jz8+/9sAQwACAQECAQECAgICAgICAgMFAwMDAwMGBAQDBQcGBwcHBgcHCAkLCQgICggHBwoNCgoLDAwMDAcJDg8NDA4LDAwM/9sAQwECAgIDAwMGAwMGDAgHCAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwM/8AAEQgBGgGGAwEiAAIRAQMRAf/EAB8AAAEFAQEBAQEBAAAAAAAAAAABAgMEBQYHCAkKC//EALUQAAIBAwMCBAMFBQQEAAABfQECAwAEEQUSITFBBhNRYQcicRQygZGhCCNCscEVUtHwJDNicoIJChYXGBkaJSYnKCkqNDU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6g4SFhoeIiYqSk5SVlpeYmZqio6Slpqeoqaqys7S1tre4ubrCw8TFxsfIycrS09TV1tfY2drh4uPk5ebn6Onq8fLz9PX29/j5+v/EAB8BAAMBAQEBAQEBAQEAAAAAAAABAgMEBQYHCAkKC//EALURAAIBAgQEAwQHBQQEAAECdwABAgMRBAUhMQYSQVEH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"
 alt="" width="260" height="150"/></div>
]]></xsl:text>
		</div>
	<div style="clear:both;"></div>
		<table id="kunye">
			<tbody>
													<tr>
											<th>
												<xsl:text>Tarih:</xsl:text>
											</th>
											<td>
											<xsl:for-each select="n1:Invoice">
											<xsl:for-each select="cbc:IssueDate">
											<xsl:value-of select="substring(.,9,2)"
											/>-<xsl:value-of select="substring(.,6,2)"
											/>-<xsl:value-of select="substring(.,1,4)"/>
											</xsl:for-each>
											</xsl:for-each>
											</td>
										</tr>
											<tr>
											<th>
												<xsl:text>Fatura No:</xsl:text>
											</th>
											<td>
												<xsl:for-each select="n1:Invoice">
												<xsl:for-each select="cbc:ID">
												<xsl:apply-templates/>
												</xsl:for-each>
												</xsl:for-each>
											</td>
										</tr>
										<tr>
											<th style="width:105px;">
												<xsl:text>Özelleştirme No:</xsl:text>
											</th>
											<td style="width:110px;">
												<xsl:for-each select="n1:Invoice">
												<xsl:for-each select="cbc:CustomizationID">
												<xsl:apply-templates/>
												</xsl:for-each>
												</xsl:for-each>
											</td>
										</tr>
										<tr>
											<th>
												<xsl:text>Senaryo:</xsl:text>
											</th>
											<td>
												<xsl:for-each select="n1:Invoice">
												<xsl:for-each select="cbc:ProfileID">
												<xsl:apply-templates/>
												</xsl:for-each>
												</xsl:for-each>
											</td>
										</tr>
										<tr>
											<th>
												<xsl:text>Fatura Tipi:</xsl:text>
											</th>
											<td>
												<xsl:for-each select="n1:Invoice">
												<xsl:for-each select="cbc:InvoiceTypeCode">
												<xsl:apply-templates/>
												</xsl:for-each>
												</xsl:for-each>
											</td>
										</tr>
<xsl:if test="//n1:Invoice/cbc:AccountingCost !=''">
										<tr>
											<th>
												<xsl:text>Fatura Alt Tipi:</xsl:text>
											</th>
											<td>
												<xsl:for-each select="n1:Invoice">
												<xsl:for-each select="cbc:AccountingCost">
												<xsl:apply-templates/>
												</xsl:for-each>
												</xsl:for-each>
											</td>
										</tr>
</xsl:if> 
<xsl:if test="//n1:Invoice/cac:AdditionalDocumentReference[cbc:DocumentType = 'İade Edilen Fatura'] or //n1:Invoice/cac:BillingReference/cac:InvoiceDocumentReference[cbc:DocumentType = 'İade Edilen Fatura']">
								<xsl:choose>
									<xsl:when test="//n1:Invoice/cac:BillingReference/cac:InvoiceDocumentReference[cbc:DocumentType = 'İade Edilen Fatura']">
										<tr>
											<th style="vertical-align:top;">
												<xsl:text>İade Fatura No:</xsl:text>
											</th>
											<td>
												<xsl:for-each select="//n1:Invoice/cac:BillingReference/cac:InvoiceDocumentReference[cbc:DocumentType = 'İade Edilen Fatura']">
												<xsl:if test="position() !=1"><br/></xsl:if>
												<xsl:value-of select="cbc:ID"/>
												</xsl:for-each>
											</td>
										</tr>
										<tr>
											<th style="vertical-align:top;">
												<xsl:text>İade Fatura Tarihi:</xsl:text>
											</th>
											<td>
												<xsl:for-each select="//n1:Invoice/cac:BillingReference/cac:InvoiceDocumentReference[cbc:DocumentType = 'İade Edilen Fatura']">
												<xsl:if test="position() !=1"><br/></xsl:if>
												<xsl:value-of select="substring(cbc:IssueDate,9,2)"
												/>-<xsl:value-of select="substring(cbc:IssueDate,6,2)"
												/>-<xsl:value-of select="substring(cbc:IssueDate,1,4)"/>
												</xsl:for-each>
											</td>
										</tr>
									</xsl:when>
									<xsl:when test="//n1:Invoice/cac:AdditionalDocumentReference[cbc:DocumentType = 'İade Edilen Fatura']">
										<tr>
											<th style="vertical-align:top;">
												<xsl:text>İade Fatura No:</xsl:text>
											</th>
											<td>
												<xsl:for-each select="//n1:Invoice/cac:AdditionalDocumentReference[cbc:DocumentType = 'İade Edilen Fatura']">
												<xsl:if test="position() !=1"><br/></xsl:if>
												<xsl:value-of select="cbc:ID"/>
												</xsl:for-each>
											</td>
										</tr>
										<tr>
											<th style="vertical-align:top;">
												<xsl:text>İade Fatura Tarihi:</xsl:text>
											</th>
											<td>
												<xsl:for-each select="//n1:Invoice/cac:AdditionalDocumentReference[cbc:DocumentType = 'İade Edilen Fatura']">
												<xsl:if test="position() !=1"><br/></xsl:if>
												<xsl:value-of select="substring(cbc:IssueDate,9,2)"
												/>-<xsl:value-of select="substring(cbc:IssueDate,6,2)"
												/>-<xsl:value-of select="substring(cbc:IssueDate,1,4)"/>
												</xsl:for-each>
											</td>
										</tr>
									</xsl:when>
								</xsl:choose>
</xsl:if> 
										<xsl:for-each
											select="n1:Invoice/cac:DespatchDocumentReference">
											<tr>
											<th>
											<xsl:text>İrsaliye No:</xsl:text>
											</th>
											<td>
											<xsl:call-template name="removeLeadingZeros">  
											  <xsl:with-param name="originalString" select="cbc:ID"/>
											</xsl:call-template>
											</td>
											</tr>
											<tr>
											<th>
												<xsl:text>İrsaliye Tarihi:</xsl:text>
											</th>
											<td>
												<xsl:for-each select="cbc:IssueDate">
												<xsl:value-of select="substring(.,9,2)"
												/>-<xsl:value-of select="substring(.,6,2)"
												/>-<xsl:value-of select="substring(.,1,4)"/>
												</xsl:for-each>
											</td>
											</tr>
										</xsl:for-each>
<xsl:if test="//n1:Invoice/cac:OrderReference">
											<tr>
											<th>
												<xsl:text>Sipariş No:</xsl:text>
											</th>
											<td>
												<xsl:for-each
												select="n1:Invoice/cac:OrderReference">
												<xsl:for-each select="cbc:ID">
												<xsl:apply-templates/>
												</xsl:for-each>
												</xsl:for-each>
											</td>
											</tr>
											<tr>
											<th>
												<xsl:text>Sipariş Tarihi:</xsl:text>
											</th>
											<td>
												<xsl:for-each
												select="n1:Invoice/cac:OrderReference">
												<xsl:for-each select="cbc:IssueDate">
												<xsl:value-of select="substring(.,9,2)"
												/>-<xsl:value-of select="substring(.,6,2)"
												/>-<xsl:value-of select="substring(.,1,4)"/>
												</xsl:for-each>
												</xsl:for-each>
											</td>
											</tr>
</xsl:if> 
<xsl:if test="//n1:Invoice/cac:PaymentMeans/cbc:PaymentDueDate or //n1:Invoice/cac:PaymentTerms/cbc:PaymentDueDate">
											<xsl:choose>
												<xsl:when test="//n1:Invoice/cac:PaymentTerms/cbc:PaymentDueDate">
													<tr>
														<th>
															<xsl:text>Son Ödeme Tarihi:</xsl:text>
														</th>
														<td>
															<xsl:for-each select="n1:Invoice/cac:PaymentTerms">
																<xsl:for-each select="cbc:PaymentDueDate">
																	<xsl:value-of select="substring(.,9,2)"/>-<xsl:value-of select="substring(.,6,2)"/>-<xsl:value-of select="substring(.,1,4)"/> <br/>
																</xsl:for-each>
															</xsl:for-each>
														</td>
													</tr>
												</xsl:when>
												<xsl:otherwise>
													<xsl:if test="//n1:Invoice/cac:PaymentMeans/cbc:PaymentDueDate">
													<tr>
														<th>
															<xsl:text>Son Ödeme Tarihi:</xsl:text>
														</th>
														<td>
															<xsl:for-each select="n1:Invoice/cac:PaymentMeans">
																<xsl:for-each select="cbc:PaymentDueDate">
																	<xsl:value-of select="substring(.,9,2)"/>-<xsl:value-of select="substring(.,6,2)"/>-<xsl:value-of select="substring(.,1,4)"/> <br/>
																</xsl:for-each>
															</xsl:for-each>
														</td>
													</tr>
													</xsl:if>
												</xsl:otherwise>
											</xsl:choose>
</xsl:if> 
<xsl:if test="//n1:Invoice/cbc:IssueTime">
											<tr>
												<th>
													<xsl:text>Oluşma Zamanı:</xsl:text>
												</th>
												<td>
													<xsl:value-of select="//n1:Invoice/cbc:IssueTime"/>
												</td>
											</tr>
</xsl:if> 

			</tbody>
		</table>
			

	</div> 
	</div> 

					</div> 
					<div class="ph empty ph9">
					<xsl:text disable-output-escaping="yes"><![CDATA[<div> </div>
]]></xsl:text>
					</div>
					<div class="satirlar"> 
						
					<table id="malHizmetTablosu">
						<tbody>
							<tr>
															<th data-id="SATIRLAR_SIRANO">
									<xsl:text>Sıra No</xsl:text>
								</th>
								<th data-id="SATIRLAR_MALHIZMET">
									<xsl:text>Ürün Kodu</xsl:text>
								</th>
								<th data-id="SATIRLAR_MALHIZMET" class="alignLeft">
									<xsl:text>Mal Hizmet</xsl:text>
								</th>
								<th data-id="SATIRLAR_MIKTAR">
									<xsl:text>Miktar</xsl:text>
								</th>
								<th data-id="SATIRLAR_BIRIMFIYAT">
									<xsl:text>Birim Fiyat</xsl:text>
								</th>
<xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:AllowanceCharge/cbc:MultiplierFactorNumeric and //n1:Invoice/cac:InvoiceLine/cac:AllowanceCharge/cbc:MultiplierFactorNumeric !=0">
								<th data-id="SATIRLAR_ISKONTOORANI">
									<xsl:text>İskonto/Artırım Oranı</xsl:text>
								</th>
</xsl:if> 
<xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:AllowanceCharge">
								<th data-id="SATIRLAR_ISKONTOTUTARI">
									<xsl:text>İskonto/(A)rtırım Tutarı</xsl:text>
								</th>
</xsl:if> 
								<th data-id="SATIRLAR_MHTUTARI" class="mhColumn">
									<xsl:text>Mal Hizmet Tutarı</xsl:text>
								</th>
<xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode ='0015'">
								<th data-id="SATIRLAR_KDVORANI">
									<xsl:text>KDV Oranı</xsl:text>
								</th>
</xsl:if> 
<xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode ='0015'">
								<th data-id="SATIRLAR_KDVTUTARI">
									<xsl:text>KDV Tutarı</xsl:text>
								</th>
</xsl:if> 
<!-- <xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cbc:TaxExemptionReasonCode > 0"> -->
								<!-- <th data-id="SATIRLAR_VERGIIADEMUAFIYET"> -->
									<!-- <xsl:text>Vergi İ.M. Sebebi</xsl:text> -->
								<!-- </th> -->
<!-- </xsl:if>  -->
<xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode !='0015' or //n1:Invoice/cac:InvoiceLine/cac:WithholdingTaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme">
								<th data-id="SATIRLAR_DIGERVERGI">
									<xsl:text>Diğer Vergiler</xsl:text>
								</th>
</xsl:if> 

							</tr>
								<xsl:for-each select="//n1:Invoice/cac:InvoiceLine">
									<xsl:apply-templates select="."/>
								</xsl:for-each>
							</tbody>
						</table>
				</div>

	</xsl:for-each> 
			<div id="toplamlarContainer">
						<div class="toplamlar">
							<div class="toplamTablo"> 
				<table>
					<tr>
						<th>
							<xsl:text>Mal Hizmet Toplam Tutarı:</xsl:text>
						</th>
						<td>
								<xsl:value-of
									select="format-number(//n1:Invoice/cac:LegalMonetaryTotal/cbc:LineExtensionAmount, '###.##0,00', 'european')"/>
								<xsl:if
									test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:LineExtensionAmount/@currencyID">
									<xsl:text> </xsl:text><span>
									<xsl:if
										test="//n1:Invoice/cbc:DocumentCurrencyCode = 'TRY' or //n1:Invoice/cbc:DocumentCurrencyCode = 'TRL'">
										<xsl:text>TL</xsl:text>
									</xsl:if>
									<xsl:if
										test="//n1:Invoice/cbc:DocumentCurrencyCode != 'TRY' and //n1:Invoice/cbc:DocumentCurrencyCode != 'TRL'">
										<xsl:value-of
											select="//n1:Invoice/cac:LegalMonetaryTotal/cbc:LineExtensionAmount/@currencyID"
										/>
									</xsl:if></span>
								</xsl:if>
						</td>
					</tr>
					<xsl:if test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:AllowanceTotalAmount !=0">
					<tr>
						<th>
								<xsl:text>Toplam İskonto: </xsl:text>
						</th>
						<td>
								<xsl:value-of select="format-number(//n1:Invoice/cac:LegalMonetaryTotal/cbc:AllowanceTotalAmount, '###.##0,00', 'european')"/>
								<xsl:if
									test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:AllowanceTotalAmount/@currencyID">
									<xsl:text> </xsl:text><span>
									<xsl:if
										test="//n1:Invoice/cbc:DocumentCurrencyCode = 'TRY' or //n1:Invoice/cbc:DocumentCurrencyCode = 'TRL'">
										<xsl:text>TL</xsl:text>
									</xsl:if>
									<xsl:if
										test="//n1:Invoice/cbc:DocumentCurrencyCode != 'TRY' and //n1:Invoice/cbc:DocumentCurrencyCode != 'TRL'">
										<xsl:value-of
											select="//n1:Invoice/cac:LegalMonetaryTotal/cbc:AllowanceTotalAmount/@currencyID"
										/>
									</xsl:if></span>
								</xsl:if>
						</td>
					</tr>
					</xsl:if>
					<xsl:if test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:ChargeTotalAmount !=0">
					<tr>
						<th>
							<xsl:text>Toplam Artırım:</xsl:text>
						</th>
						<td>
								<xsl:value-of
									select="format-number(//n1:Invoice/cac:LegalMonetaryTotal/cbc:ChargeTotalAmount, '###.##0,00', 'european')"/>
								<xsl:if
									test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:ChargeTotalAmount/@currencyID">
									<xsl:text> </xsl:text><span>
									<xsl:if
										test="//n1:Invoice/cbc:DocumentCurrencyCode = 'TRY' or //n1:Invoice/cbc:DocumentCurrencyCode = 'TRL'">
										<xsl:text>TL</xsl:text>
									</xsl:if>
									<xsl:if
										test="//n1:Invoice/cbc:DocumentCurrencyCode != 'TRY' and //n1:Invoice/cbc:DocumentCurrencyCode != 'TRL'">
										<xsl:value-of
											select="//n1:Invoice/cac:LegalMonetaryTotal/cbc:ChargeTotalAmount/@currencyID"
										/>
									</xsl:if></span>
								</xsl:if>
						</td>
					</tr>
					</xsl:if>
					<xsl:for-each select="//n1:Invoice/cac:TaxTotal/cac:TaxSubtotal[cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode='0015']">
					<tr>
						<th>
							<xsl:text>KDV Matrahı </xsl:text>
							<xsl:text>(%</xsl:text><xsl:value-of select="cbc:Percent"/><xsl:text>):</xsl:text>
						</th>
						
						<td>
								<xsl:value-of
									select="format-number(./cbc:TaxableAmount[../cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode='0015'], '###.##0,00', 'european')"/>
								<xsl:if
									test="./cbc:TaxableAmount/@currencyID">
									<xsl:text> </xsl:text><span>
									<xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode = 'TRY' or //n1:Invoice/cbc:DocumentCurrencyCode = 'TRL'">
										<xsl:text>TL</xsl:text>
									</xsl:if>
									<xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode != 'TRY' and //n1:Invoice/cbc:DocumentCurrencyCode != 'TRL'">
										<xsl:value-of
											select="./cbc:TaxableAmount/@currencyID"/>
									</xsl:if></span>
								</xsl:if>
						</td>
					</tr>
					</xsl:for-each>
					<tr>
						<th class="sumTitle">
							<span>
								<xsl:text>Vergi Hariç Tutar: </xsl:text>
							</span>
						</th>
						
						<td class="sumValue">
								<xsl:value-of
									select="format-number(//n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxExclusiveAmount, '###.##0,00', 'european')"/>
								<xsl:if
									test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxExclusiveAmount">
									<xsl:text> </xsl:text><span>
									<xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode = 'TRY' or //n1:Invoice/cbc:DocumentCurrencyCode = 'TRL'">
										<xsl:text>TL</xsl:text>
									</xsl:if>
									<xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode != 'TRY' and //n1:Invoice/cbc:DocumentCurrencyCode != 'TRL'">
										<xsl:value-of
											select="
											//n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxExclusiveAmount/@currencyID"
										/>
									</xsl:if></span>
								</xsl:if>
						</td>
					</tr>
					<xsl:for-each select="n1:Invoice/cac:TaxTotal/cac:TaxSubtotal[not(starts-with(./cac:TaxCategory/cbc:TaxExemptionReasonCode,'8') and (string-length(./cac:TaxCategory/cbc:TaxExemptionReasonCode) =3))]">
						<tr>
							
                        <th class="sumTitle is-long-{string-length(cac:TaxCategory/cac:TaxScheme/cbc:Name) > 15}">
							<xsl:text>Hesaplanan </xsl:text>
							<xsl:value-of select="cac:TaxCategory/cac:TaxScheme/cbc:Name"/>
							<xsl:text> (%</xsl:text>
							<xsl:value-of select="cbc:Percent"/>
							<xsl:text>) </xsl:text>
							<xsl:if test="cac:TaxCategory/cbc:TaxExemptionReasonCode > 0">
							(<xsl:value-of select="cac:TaxCategory/cbc:TaxExemptionReasonCode"/>)
							</xsl:if>
							<xsl:text>: </xsl:text>
						</th>
						<td class="sumValue">
							<xsl:for-each select="cac:TaxCategory/cac:TaxScheme">
								<xsl:text> </xsl:text>
								<xsl:value-of
									select="format-number(../../cbc:TaxAmount, '###.##0,00', 'european')"/><span>
								<xsl:if test="../../cbc:TaxAmount/@currencyID">
									<xsl:text> </xsl:text>
										<xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode = 'TRY' or //n1:Invoice/cbc:DocumentCurrencyCode = 'TRL'">
										<xsl:text>TL</xsl:text>
									</xsl:if>
									<xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode != 'TRY' and //n1:Invoice/cbc:DocumentCurrencyCode != 'TRL'">
										<xsl:value-of select="../../cbc:TaxAmount/@currencyID"/>
									</xsl:if>
								</xsl:if></span>
							</xsl:for-each>
						</td>
						</tr>
					</xsl:for-each>
					<xsl:if test="n1:Invoice/cac:WithholdingTaxTotal/cac:TaxSubtotal[starts-with(./cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode,'6')]">
						<tr>
						<th class="sumTitle">
									<xsl:text>Tevkifata Tabi İşlem Tutarı (KDV): </xsl:text>
							</th>
							<td class="sumValue">
								<xsl:value-of select="format-number(sum(n1:Invoice/cac:InvoiceLine/cac:TaxTotal/cac:TaxSubtotal/cbc:TaxableAmount[../../../cac:WithholdingTaxTotal/cac:TaxSubtotal[starts-with(./cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode,'6')] and ../cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode =0015]), '###.##0,00', 'european')"/>
								<span>
								<xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode = 'TRY' or //n1:Invoice/cbc:DocumentCurrencyCode = 'TRL'">
									<xsl:text> TL</xsl:text>
								</xsl:if>
								<xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode != 'TRY' and //n1:Invoice/cbc:DocumentCurrencyCode != 'TRL'">
									<xsl:text> </xsl:text><xsl:value-of select="n1:Invoice/cbc:DocumentCurrencyCode"/>
								</xsl:if>
								</span>
							</td>
						</tr>
						<tr>
							<th>
									<xsl:text>Tevkifata Tabi İşlem Üzerinden Hes. KDV: </xsl:text>
							</th>
							<td class="sumValue">
								<xsl:value-of select="format-number(sum(n1:Invoice/cac:WithholdingTaxTotal/cac:TaxSubtotal/cbc:TaxableAmount[starts-with(../cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode,'6')]), '###.##0,00', 'european')"/>
								<span><xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode = 'TRY' or //n1:Invoice/cbc:DocumentCurrencyCode = 'TRL'">
									<xsl:text> TL</xsl:text>
								</xsl:if>
								<xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode != 'TRY' and //n1:Invoice/cbc:DocumentCurrencyCode != 'TRL'">
									<xsl:text> </xsl:text><xsl:value-of select="n1:Invoice/cbc:DocumentCurrencyCode"/>
								</xsl:if></span>
							</td>
						</tr>

						<xsl:for-each select="n1:Invoice/cac:WithholdingTaxTotal/cac:TaxSubtotal[starts-with(./cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode,'6')]">
						<tr>
							<th>
								<xsl:text>KDV Tevkifat Tutarı (</xsl:text><xsl:value-of select="./cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode"/>):
							</th>
							<td class="sumValue">
								<xsl:value-of select="format-number(cbc:TaxAmount, '###.##0,00', 'european')"/>
								<span><xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode = 'TRY' or //n1:Invoice/cbc:DocumentCurrencyCode = 'TRL'">
									<xsl:text> TL</xsl:text>
								</xsl:if>
								<xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode != 'TRY' and //n1:Invoice/cbc:DocumentCurrencyCode != 'TRL'">
									<xsl:text> </xsl:text><xsl:value-of select="//n1:Invoice/cbc:DocumentCurrencyCode"/>
								</xsl:if></span>
							</td>
						</tr>
						</xsl:for-each>

					</xsl:if>


					<xsl:if test="n1:Invoice/cac:WithholdingTaxTotal/cac:TaxSubtotal[starts-with(./cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode,'4')]">
						<tr>
							<th>
								<xsl:text>Tevkifata Tabi İşlem Tutarı (ÖTV)</xsl:text>
							</th>
							<td class="sumValue">
								<xsl:value-of select="format-number(sum(n1:Invoice/cac:InvoiceLine/cac:TaxTotal/cac:TaxSubtotal/cbc:TaxableAmount[../../../cac:WithholdingTaxTotal/cac:TaxSubtotal[starts-with(./cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode,'4') and ../cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode =0071]]), '###.##0,00', 'european')"/>
								<span><xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode = 'TRY' or //n1:Invoice/cbc:DocumentCurrencyCode = 'TRL'">
									<xsl:text> TL</xsl:text>
								</xsl:if>
								<xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode != 'TRY' and //n1:Invoice/cbc:DocumentCurrencyCode != 'TRL'">
									<xsl:value-of select="n1:Invoice/cbc:DocumentCurrencyCode"/>
								</xsl:if></span>
							</td>
						</tr>
						<tr>
							<th>
								<xsl:text>Tevkifata Tabi İşlem Üzerinden Hes. ÖTV</xsl:text>
							</th>
							<td class="sumValue">
								<xsl:value-of select="format-number(sum(n1:Invoice/cac:WithholdingTaxTotal/cac:TaxSubtotal/cbc:TaxableAmount[starts-with(../cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode,'4')]), '###.##0,00', 'european')"/>
								<span><xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode = 'TRY' or //n1:Invoice/cbc:DocumentCurrencyCode = 'TRL'">
									<xsl:text> TL</xsl:text>
								</xsl:if>
								<xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode != 'TRY' and //n1:Invoice/cbc:DocumentCurrencyCode != 'TRL'">
									<xsl:value-of select="n1:Invoice/cbc:DocumentCurrencyCode"/>
								</xsl:if></span>
							</td>
						</tr>

						<xsl:for-each select="n1:Invoice/cac:WithholdingTaxTotal/cac:TaxSubtotal[starts-with(./cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode,'4')]">
						<tr>
							<th>
								<xsl:text>ÖTV Tevkifat Tutarı (</xsl:text><xsl:value-of select="./cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode"/>):
							</th>
							<td class="sumValue">
								<xsl:value-of select="../cbc:TaxAmount"/>
								<span><xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode = 'TRY' or //n1:Invoice/cbc:DocumentCurrencyCode = 'TRL'">
									<xsl:text> TL</xsl:text>
								</xsl:if>
								<xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode != 'TRY' and //n1:Invoice/cbc:DocumentCurrencyCode != 'TRL'">
									<xsl:text> </xsl:text><xsl:value-of select="//n1:Invoice/cbc:DocumentCurrencyCode"/>
								</xsl:if></span>
							</td>
						</tr>
						</xsl:for-each>

					</xsl:if>

						
						<xsl:if test="sum(n1:Invoice/cac:TaxTotal/cac:TaxSubtotal[cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode=9015]/cbc:TaxableAmount)>0">
							<tr>
								<th>
									<xsl:text>Tevkifata Tabi İşlem Tutarı:</xsl:text>
								</th>
								<td class="sumValue">
									<xsl:value-of select="format-number(sum(n1:Invoice/cac:InvoiceLine[cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode=9015]/cbc:LineExtensionAmount), '###.##0,00', 'european')"/>
									<span><xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode = 'TRY' or //n1:Invoice/cbc:DocumentCurrencyCode = 'TRL'">
										<xsl:text>TL</xsl:text>
									</xsl:if>
									<xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode != 'TRY' and //n1:Invoice/cbc:DocumentCurrencyCode != 'TRL'">
										<xsl:value-of select="n1:Invoice/cbc:DocumentCurrencyCode"/>
									</xsl:if></span>
								</td>
							</tr>
							<tr>
								<th>
									<xsl:text>Tevkifata Tabi İşlem Üzerinden Hes. KDV:</xsl:text>
								</th>
								<td class="sumValue">
									<xsl:value-of select="format-number(sum(n1:Invoice/cac:TaxTotal/cac:TaxSubtotal[cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode=9015]/cbc:TaxableAmount), '###.##0,00', 'european')"/>
									<span><xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode = 'TRY' or //n1:Invoice/cbc:DocumentCurrencyCode = 'TRL'">
										<xsl:text>TL</xsl:text>
									</xsl:if>
									<xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode != 'TRY' and //n1:Invoice/cbc:DocumentCurrencyCode != 'TRL'">
										<xsl:value-of select="n1:Invoice/cbc:DocumentCurrencyCode"/>
									</xsl:if></span>
								</td>
							</tr>
						</xsl:if>


					<tr>
						<th>
							<xsl:text>Vergiler Dahil Toplam Tutar:</xsl:text>
						</th>
						<td class="sumValue">
							<xsl:for-each select="n1:Invoice">
								<xsl:for-each select="cac:LegalMonetaryTotal">
									<xsl:for-each select="cbc:TaxInclusiveAmount">
										<xsl:value-of
											select="format-number(., '###.##0,00', 'european')"/>
										<xsl:if
											test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount/@currencyID">
											<xsl:text> </xsl:text>
											<span><xsl:if
												test="//n1:Invoice/cbc:DocumentCurrencyCode = 'TRY' or //n1:Invoice/cbc:DocumentCurrencyCode = 'TRL'">
												<xsl:text>TL</xsl:text>
											</xsl:if>
											<xsl:if
												test="//n1:Invoice/cbc:DocumentCurrencyCode != 'TRY' and //n1:Invoice/cbc:DocumentCurrencyCode != 'TRL'">
												<xsl:value-of
												select="//n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount/@currencyID"
												/>
											</xsl:if></span>
										</xsl:if>
									</xsl:for-each>
								</xsl:for-each>
							</xsl:for-each>
						</td>
					</tr>
					<tr class="payableAmount">
						<th>
							<xsl:text>Ödenecek Tutar:</xsl:text>
						</th>
						<td>
							<xsl:for-each select="n1:Invoice">
								<xsl:for-each select="cac:LegalMonetaryTotal">
									<xsl:for-each select="cbc:PayableAmount">
										<xsl:value-of
											select="format-number(., '###.##0,00', 'european')"/>
										<xsl:if
											test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:PayableAmount/@currencyID">
											<xsl:text> </xsl:text>
											<span><xsl:if
												test="//n1:Invoice/cbc:DocumentCurrencyCode = 'TRY' or //n1:Invoice/cbc:DocumentCurrencyCode = 'TRL'">
												<xsl:text>TL</xsl:text>
											</xsl:if>
											<xsl:if
												test="//n1:Invoice/cbc:DocumentCurrencyCode != 'TRY' and //n1:Invoice/cbc:DocumentCurrencyCode != 'TRL'">
												<xsl:value-of
												select="//n1:Invoice/cac:LegalMonetaryTotal/cbc:PayableAmount/@currencyID"
												/>
											</xsl:if></span>
										</xsl:if>
									</xsl:for-each>
								</xsl:for-each>
							</xsl:for-each>
						</td>
					</tr>
				</table>
				</div>


			</div>

			</div>
				<div id="notlar"> 
				<table>
					<tbody>
						<tr>
							<td>
								<xsl:for-each select="//n1:Invoice/cbc:Note">
									<xsl:if test="1=1">
										<xsl:call-template name="repNL">
											<xsl:with-param name="pText" select="." />
										</xsl:call-template>
									</xsl:if>
								</xsl:for-each>
								<div class="ekNot">
									<xsl:if test ="n1:Invoice/cbc:Note[contains(normalize-space(.),'Gönderim Şekli:ELEKTRONIK')] or n1:Invoice/cbc:Note[contains(normalize-space(.),'Gönderim Şekli: ELEKTRONIK')]">
									<span>e-Arşiv izni kapsamında elektronik ortamda iletilmiştir.</span><br/>
									</xsl:if>
									<xsl:if test ="n1:Invoice/cbc:Note[contains(.,'##internetSatis_odemeSekli')]">
									<span>Bu satış İnternet üzerinden yapılmıştır.</span>
									</xsl:if>
								</div>
								<xsl:for-each select="n1:Invoice/cac:TaxTotal/cac:TaxSubtotal[starts-with(./cac:TaxCategory/cbc:TaxExemptionReasonCode,'8') and (string-length(./cac:TaxCategory/cbc:TaxExemptionReasonCode) =3)]">
										<span style="font-weight:bold; ">Özel Matrah Kodu: </span>
										<xsl:value-of select="cac:TaxCategory/cbc:TaxExemptionReasonCode"/> - <xsl:value-of select="cac:TaxCategory/cbc:TaxExemptionReason"/>
										<br/>
										<span style="font-weight:bold; ">Özel Matrah Detayı: </span>
											<xsl:value-of select="cac:TaxCategory/cac:TaxScheme/cbc:Name"/>
											(<xsl:value-of select="cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode"/>)
											<xsl:text> Oran: %</xsl:text>
											<xsl:value-of select="cbc:Percent"/>
										
											Vergi Tutarı: 
											<xsl:value-of
												select="format-number(cbc:TaxAmount, '###.##0,00', 'european')"/>
												<xsl:text> </xsl:text>
												<xsl:if test="cbc:TaxAmount/@currencyID = 'TRY' or cbc:TaxAmount/@currencyID = 'TRL'">
													<xsl:text>TL</xsl:text>
												</xsl:if>
												<xsl:if test="cbc:TaxAmount/@currencyID != 'TRY' and cbc:TaxAmount/@currencyID != 'TRL'">
													<xsl:value-of select="cbc:TaxAmount/@currencyID"/>
												</xsl:if>
												Vergi Matrahı:
											<xsl:value-of
												select="format-number(cbc:TaxableAmount, '###.##0,00', 'european')"/>
												<xsl:text> </xsl:text>
												<xsl:if test="cbc:TaxableAmount/@currencyID = 'TRY' or cbc:TaxableAmount/@currencyID = 'TRL'">
													<xsl:text>TL</xsl:text>
												</xsl:if>
												<xsl:if test="cbc:TaxableAmount/@currencyID != 'TRY' and cbc:TaxableAmount/@currencyID != 'TRL'">
													<xsl:value-of select="cbc:TaxableAmount/@currencyID"/>
												</xsl:if>
										<br/>
								</xsl:for-each>

								<xsl:if test="n1:Invoice/cac:WithholdingTaxTotal/cac:TaxSubtotal[starts-with(./cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode,'4') or starts-with(./cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode,'6')]">
									<br/><span style="display:inline-block;font-weight:bold;  vertical-align: top;padding-right: 4px;">TEVKİFAT DETAYI: </span>
									<span style="display:inline-block;">
										<xsl:for-each select="n1:Invoice/cac:WithholdingTaxTotal/cac:TaxSubtotal[starts-with(./cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode,'4') or starts-with(./cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode,'6')]">
											<xsl:value-of select="./cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode"/> - <xsl:value-of select="./cac:TaxCategory/cac:TaxScheme/cbc:Name"/> <br/>
										</xsl:for-each>
									</span>
									<div style="clear:both"></div>
								</xsl:if>

								<xsl:if test="//n1:Invoice/cac:AdditionalDocumentReference and //n1:Invoice/cac:AdditionalDocumentReference/cbc:DocumentType!='XSLT'">
									<xsl:for-each select="//n1:Invoice/cac:AdditionalDocumentReference">
									<xsl:if test="./cbc:DocumentType!='XSLT' and not(./cbc:DocumentTypeCode)">
									<br/><span style="font-weight:bold;">İLAVE DÖKÜMANLAR</span><br/>
									<xsl:if test="./cbc:ID">
										<span style="font-weight:bold;"> Belge No: </span>
										<xsl:value-of
                                                select="./cbc:ID"/>
									</xsl:if>
									<xsl:if test="./cbc:IssueDate">
										<span style="font-weight:bold;"> Belge Tarihi: </span>
										<xsl:value-of select="substring(./cbc:IssueDate,9,2)"
												/>-<xsl:value-of select="substring(./cbc:IssueDate,6,2)"
												/>-<xsl:value-of select="substring(./cbc:IssueDate,1,4)"/>
										
									</xsl:if>
									<xsl:if test="./cbc:DocumentType">
										<span style="font-weight:bold;"> Belge Tipi: </span>
										<xsl:value-of
                                                select="./cbc:DocumentType"/>
									</xsl:if>

									<xsl:if test="./cac:Attachment">
										<span style="font-weight:bold;"> Belge Adı: </span>
										<xsl:if test="./cac:Attachment/cbc:EmbeddedDocumentBinaryObject">
										<xsl:value-of
                                                select="./cac:Attachment/cbc:EmbeddedDocumentBinaryObject/@filename"/>
                                         </xsl:if>
									</xsl:if>

									<br/>
									</xsl:if>
								</xsl:for-each>
								</xsl:if>

								
								<xsl:if test="//n1:Invoice/cac:PaymentMeans">
								<br/><span style="font-weight:bold;">ÖDEME ŞEKLİ</span><br/>
								
								
								<xsl:for-each select="//n1:Invoice/cac:PaymentMeans">
									<xsl:if test="./cbc:PaymentMeansCode">
										<span style="font-weight:bold;">Ödeme Şekli: </span>
										

								<xsl:choose>
								<xsl:when test="./cbc:PaymentMeansCode  = 'ZZZ'">
									<span>
										<xsl:text>Diğer</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="./cbc:PaymentMeansCode  = '20'">
									<span>
										<xsl:text>Çek</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="./cbc:PaymentMeansCode  = '42'">
									<span>
										<xsl:text>Havale</xsl:text>
									</span>
								</xsl:when>
								
								<xsl:when test="./cbc:PaymentMeansCode  = '6'">
									<span>
										<xsl:text>Kredi</xsl:text>
									</span>
								</xsl:when>
								
								<xsl:when test="./cbc:PaymentMeansCode  = '48'">
									<span>
										<xsl:text>Kredi Kartı</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="./cbc:PaymentMeansCode  = '10'">
									<span>
										<xsl:text>Nakit</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="./cbc:PaymentMeansCode  = '49'">
									<span>
										<xsl:text>Otomatik Ödeme</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="./cbc:PaymentMeansCode  = '60'">
									<span>
										<xsl:text>Senet</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="./cbc:PaymentMeansCode  = '1'">
									<span>
										<xsl:text>Sözleşme Kapsamında</xsl:text>
									</span>
								</xsl:when>

								</xsl:choose>

								</xsl:if>

								&#160;&#160;&#160;

								<xsl:if test="cbc:PaymentDueDate">
										<span style="font-weight:bold;">Son Ödeme Tarihi: </span>
										<xsl:value-of select="substring(cbc:PaymentDueDate,9,2)"
												/>-<xsl:value-of select="substring(cbc:PaymentDueDate,6,2)"
												/>-<xsl:value-of select="substring(cbc:PaymentDueDate,1,4)"/>&#160;&#160;&#160;
										
									</xsl:if>
									<xsl:if test="cbc:PaymentChannelCode">
										<span style="font-weight:bold;">Ödeme Kanalı: </span>
										<xsl:value-of
                                                select="cbc:PaymentChannelCode"/>&#160;&#160;&#160;
									</xsl:if>

									<xsl:if test="cac:PayeeFinancialAccount/cbc:ID">
											<span style="font-weight:bold;"> IBAN / Hesap No: </span>
											<xsl:value-of select="cac:PayeeFinancialAccount/cbc:ID"/>
											(<xsl:if test="cac:PayeeFinancialAccount/cbc:CurrencyCode = 'TRY' or cac:PayeeFinancialAccount/cbc:CurrencyCode = 'TRL'"><xsl:text>TL</xsl:text></xsl:if><xsl:if test="cac:PayeeFinancialAccount/cbc:CurrencyCode != 'TRY' and cac:PayeeFinancialAccount/cbc:CurrencyCode != 'TRL'"><xsl:value-of select="cac:PayeeFinancialAccount/cbc:CurrencyCode"/></xsl:if>)
									</xsl:if>

									<xsl:if test="cbc:InstructionNote">
										<br/><span style="font-weight:bold;">Ödeme Şekli Açıklaması:</span>
										<xsl:value-of
                                                select="cbc:InstructionNote"/>&#160;&#160;&#160;
									</xsl:if>


									<br/>

								</xsl:for-each>

								</xsl:if>

								
								<xsl:if test="//n1:Invoice/cac:InvoicePeriod">
								<br/><span style="font-weight:bold;">FATURA DÖNEM BİLGİLERİ</span><br/>
								
								
								<xsl:for-each select="//n1:Invoice/cac:InvoicePeriod">
									<xsl:if test="./cbc:StartDate">
										<span style="font-weight:bold;">Başlangıç Tarihi:</span>&#160;
										<xsl:value-of select="substring(./cbc:StartDate,9,2)"
												/>-<xsl:value-of select="substring(./cbc:StartDate,6,2)"
												/>-<xsl:value-of select="substring(./cbc:StartDate,1,4)"/>&#160;&#160;&#160;
										
										
									</xsl:if>
									<xsl:if test="./cbc:EndDate">
										<span style="font-weight:bold;">Bitiş Tarihi:</span>&#160;
										<xsl:value-of select="substring(./cbc:EndDate,9,2)"
												/>-<xsl:value-of select="substring(./cbc:EndDate,6,2)"
												/>-<xsl:value-of select="substring(./cbc:EndDate,1,4)"/>&#160;&#160;&#160;
										
									</xsl:if>

									<xsl:if test="./cbc:DurationMeasure">
										<span style="font-weight:bold;">Dönem Periyodu / Süresi: </span>
										<xsl:value-of
                                                select="./cbc:DurationMeasure"/>&#160;
										<xsl:choose>
								<xsl:when test="./cbc:DurationMeasure/@unitCode  = 'MON'">
									<span>
										<xsl:text>Ay</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="./cbc:DurationMeasure/@unitCode  = 'DAY'">
									<span>
										<xsl:text>Gün</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="./cbc:DurationMeasure/@unitCode  = 'HUR'">
									<span>
										<xsl:text>Saat</xsl:text>
									</span>
								</xsl:when>
								
								<xsl:when test="./cbc:DurationMeasure/@unitCode  = 'ANN'">
									<span>
										<xsl:text>Yıl</xsl:text>
									</span>
								</xsl:when>

								</xsl:choose>

								&#160;

								</xsl:if>

								<br/>

								<xsl:if test="./cbc:Description">
									<span style="font-weight:bold;">Fatura Dönem Açıklaması:</span>&#160;
									<xsl:value-of select="./cbc:Description"/>&#160;&#160;&#160;
								</xsl:if>	

								</xsl:for-each>
								<br/>
								</xsl:if>
								<xsl:if test="//n1:Invoice/cac:ReceiptDocumentReference">
									<br/><span style="font-weight:bold;">ALINDI BİLGİLERİ</span><br/>
									<xsl:for-each select="//n1:Invoice/cac:ReceiptDocumentReference">
										<xsl:if test="./cbc:ID">
											<span style="font-weight:bold;">Belge Numarası: </span>
											<xsl:value-of select="./cbc:ID"/>
										</xsl:if>
										<xsl:if test="./cbc:IssueDate">
											<span style="font-weight:bold;"> Belge Tarihi: </span>
											<xsl:value-of select="substring(./cbc:IssueDate,9,2)"
												/>-<xsl:value-of select="substring(./cbc:IssueDate,6,2)"
												/>-<xsl:value-of select="substring(./cbc:IssueDate,1,4)"/>
										</xsl:if>
										<xsl:if test="./cbc:DocumentType">
											<span style="font-weight:bold;"> Belge Tipi: </span>
											<xsl:value-of select="./cbc:DocumentType"/>
										</xsl:if>
										<br/>
									</xsl:for-each>
								</xsl:if>
								<xsl:if test="//n1:Invoice/cac:PaymentTerms/cbc:PenaltySurchargePercen or //n1:Invoice/cac:PaymentTerms/cbc:Amount or //n1:Invoice/cac:PaymentTerms/cbc:Note">
									<br/><span style="font-weight:bold;">ÖDEME KOŞULLARI</span><br/>
								
								<xsl:for-each select="//n1:Invoice/cac:PaymentTerms">
									<xsl:if test="./cbc:PenaltySurchargePercent">
										<span style="font-weight:bold;">Gecikme Ceza Oranı: </span>
										<xsl:text> %</xsl:text>
									<xsl:value-of
									select="format-number(./cbc:PenaltySurchargePercent, '###.##0,00', 'european')"/>&#160;&#160;&#160;
									</xsl:if>
									<xsl:if test="./cbc:Amount">
										<span style="font-weight:bold;">Gecikme Ceza Tutarı:</span>&#160;
										<xsl:value-of select="format-number(./cbc:Amount, '###.##0,00', 'european')"/>
									</xsl:if>

									<xsl:if test="./cbc:Amount/@currencyID">
										<xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode = 'TRY' or //n1:Invoice/cbc:DocumentCurrencyCode = 'TRL'">
											<xsl:text> TL</xsl:text>&#160;&#160;&#160;
										</xsl:if>
										<xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode != 'TRY' and //n1:Invoice/cbc:DocumentCurrencyCode != 'TRL'">
											<xsl:value-of select="./cac:Price/cbc:PriceAmount/@currencyID"/>&#160;&#160;&#160;
										</xsl:if>
									</xsl:if>


									<xsl:if test="./cbc:Note">
										<span style="font-weight:bold;">Açıklama: </span>
										<xsl:value-of
                                                select="./cbc:Note"/>
									</xsl:if>

									<br/>

								</xsl:for-each>
								<br/>
								</xsl:if>

					
                    <xsl:for-each select="//n1:Invoice/cac:TaxTotal/cac:TaxSubtotal">
						<xsl:if test="cbc:Percent=0 and cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode=&apos;0015&apos; and not(cac:TaxCategory/cbc:TaxExemptionReasonCode > 0)">  
							<b>Vergi İstisna Muafiyet Sebebi: </b>
							<xsl:value-of select="cac:TaxCategory/cbc:TaxExemptionReason"/>
							<br/>
						</xsl:if>
                    </xsl:for-each>

					
	                <xsl:for-each select="//n1:Invoice/cac:TaxTotal/cac:TaxSubtotal[not(./cac:TaxCategory/cbc:TaxExemptionReasonCode=preceding::*)]">
	                    	<xsl:if test="cac:TaxCategory/cbc:TaxExemptionReasonCode > 0 and not(starts-with(./cac:TaxCategory/cbc:TaxExemptionReasonCode,'8') and (string-length(./cac:TaxCategory/cbc:TaxExemptionReasonCode) =3))">
	                        <b>Vergi İstisna Muafiyet Sebebi: </b>
							<xsl:value-of select="cac:TaxCategory/cbc:TaxExemptionReasonCode"/> - <xsl:value-of select="cac:TaxCategory/cbc:TaxExemptionReason"/> - <xsl:value-of select="cac:TaxCategory/cbc:Name"/>
	                        <br/>
	                    </xsl:if>
	                </xsl:for-each>
					
							</td>
						</tr>
					</tbody>
				</table>
			</div> 
			<div class="ph empty ph12">
			<xsl:text disable-output-escaping="yes"><![CDATA[<span style="font-family: tahoma, arial, helvetica, sans-serif;"><span style="color: #000000;"><strong>Faturanıza</strong></span></span><span style="font-family: tahoma, arial, helvetica, sans-serif;"><span style="color: #000000;"><strong> bu linkten ulaşabilirsiniz:</strong></span> <span style="color: #0000ff;">https://earsiv.efinans.com.tr/earsiv/sorgula.jsp</span></span>
]]></xsl:text>
			</div>

				</div> 
			</div>
	</body>

	</html>

	</xsl:template>
	
			<xsl:template match="//n1:Invoice/cac:InvoiceLine"> 
				<tr>
							<td>
				<span>
					<xsl:value-of select="format-number(./cbc:ID, '#')"/>
				</span>
			</td>
			
						<td>
				<span>
					<xsl:value-of select="./cac:Item/cac:SellersItemIdentification/cbc:ID"/>
				</span>
			</td>
			
			<td class="wrap">
				<span>
					<xsl:value-of select="./cac:Item/cbc:Name"/>
					<xsl:text>&#160;</xsl:text>
					<xsl:value-of select="./cac:Item/cbc:BrandName"/>
					<xsl:text>&#160;</xsl:text>
					<xsl:value-of select="./cac:Item/cbc:ModelName"/>
					<xsl:text>&#160;</xsl:text>
					<xsl:value-of select="./cac:Item/cac:CommodityClassification/cbc:ItemClassificationCode"/>
					<xsl:text>&#160;</xsl:text>
					<xsl:value-of select="./cac:Item/cac:ItemInstance/cbc:SerialID"/>
				</span>
			</td>
			<td>
				<span>
					<xsl:value-of
						select="format-number(./cbc:InvoicedQuantity, '#.###.###,########', 'european')"/>
					<xsl:if test="./cbc:InvoicedQuantity/@unitCode">
						<xsl:for-each select="./cbc:InvoicedQuantity">
							<xsl:text> </xsl:text>
							<xsl:choose>
								<xsl:when test="@unitCode  = '26'">
									<span>
										<xsl:text>Ton</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'SET'">
									<span>
										<xsl:text>Set</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'BX'">
									<span>
										<xsl:text>Kutu</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'LTR'">
									<span>
										<xsl:text>LT</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'HUR'">
									<span>
										<xsl:text>Saat</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'NIU' or @unitCode  = 'C62'">
									<span>
										<xsl:text>Adet</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'KGM'">
									<span>
										<xsl:text>KG</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'KJO'">
									<span>
										<xsl:text>kJ</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'GRM'">
									<span>
										<xsl:text>G</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'MGM'">
									<span>
										<xsl:text>MG</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'NT'">
									<span>
										<xsl:text>Net Ton</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'GT'">
									<span>
										<xsl:text>GT</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'MTR'">
									<span>
										<xsl:text>M</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'MMT'">
									<span>
										<xsl:text>MM</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'KTM'">
									<span>
										<xsl:text>KM</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'MLT'">
									<span>
										<xsl:text>ML</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'MMQ'">
									<span>
										<xsl:text>MM3</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'CLT'">
									<span>
										<xsl:text>CL</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'CMK'">
									<span>
										<xsl:text>CM2</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'CMQ'">
									<span>
										<xsl:text>CM3</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'CMT'">
									<span>
										<xsl:text>CM</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'DMT'">
									<span>
										<xsl:text>DM</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'MTK'">
									<span>
										<xsl:text>M2</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'MTQ'">
									<span>
										<xsl:text>M3</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'DAY'">
									<span>
										<xsl:text> Gün</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'MON'">
									<span>
										<xsl:text> Ay</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'PA'">
									<span>
										<xsl:text> Paket</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'KWH'">
									<span>
										<xsl:text> KWH</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'D61'">
									<span>
										<xsl:text> Dakika</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'D62'">
									<span>
										<xsl:text> Saniye</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'ANN'">
									<span>
										<xsl:text> Yıl</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'AFF'">
									<span>
										<xsl:text> AFİF</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'AYR'">
									<span>
										<xsl:text> Altın Ayarı</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'B32'">
									<span>
										<xsl:text> KG/Metre Kare</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'CCT'">
									<span>
										<xsl:text> Ton Başına Taşıma Kapasitesi</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'CPR'">
									<span>
										<xsl:text> Adet-Çift</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'D30'">
									<span>
										<xsl:text> Brüt Kalori Değeri</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'D40'">
									<span>
										<xsl:text> Bin Litre</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'GFI'">
									<span>
										<xsl:text> FISSILE İzotop Gramı</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'GMS'">
									<span>
										<xsl:text> Gümüş</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'GRM'">
									<span>
										<xsl:text> Gram</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'H62'">
									<span>
										<xsl:text> Yüz Adet</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'K20'">
									<span>
										<xsl:text> Kilogram Potasyum Oksit</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'K58'">
									<span>
										<xsl:text> Kurutulmuş Net Ağırlıklı Kg.</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'K62'">
									<span>
										<xsl:text> Kilogram-Adet</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'KFO'">
									<span>
										<xsl:text> Difosfor Pentaoksit Kilogramı</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'KGM'">
									<span>
										<xsl:text> Kilogram</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'KH6'">
									<span>
										<xsl:text> Kilogram-Baş</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'KHO'">
									<span>
										<xsl:text> Hidrojen Peroksit Kilogramı</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'KMA'">
									<span>
										<xsl:text> Metil Aminlerin Kilogramı</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'KNI'">
									<span>
										<xsl:text> Azotun Kilogramı</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'KOH'">
									<span>
										<xsl:text> Kg. Potasyum Hidroksit</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'KPH'">
									<span>
										<xsl:text> Kg Potasyum Oksid</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'KPR'">
									<span>
										<xsl:text> Kilogram-Çift</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'KSD'">
									<span>
										<xsl:text> %90 Kuru Ürün Kg.</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'KSH'">
									<span>
										<xsl:text> Sodyum Hidroksit Kg.</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'KUR'">
									<span>
										<xsl:text> Uranyum Kilogramı</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'KWH'">
									<span>
										<xsl:text> Kilowatt Saat</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'KWT'">
									<span>
										<xsl:text> Kilowatt</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'LPA'">
									<span>
										<xsl:text> Saf Alkol Litresi</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'LTR'">
									<span>
										<xsl:text> Litre</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'MTR'">
									<span>
										<xsl:text> Metre</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'NCL'">
									<span>
										<xsl:text> Hücre Adedi</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'NCR'">
									<span>
										<xsl:text> Karat</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'OMV'">
									<span>
										<xsl:text> OTV Maktu Vergi</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'OTB'">
									<span>
										<xsl:text> OTV birim fiyatı</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'PR'">
									<span>
										<xsl:text> Çift</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'R9'">
									<span>
										<xsl:text> Bin Metre Küp</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'T3'">
									<span>
										<xsl:text> Bin Adet</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'TWH'">
									<span>
										<xsl:text> Bin Kilowatt Saat</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode = 'GRO'">
									<span>
										<xsl:text> Grosa</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode = 'DZN'">
									<span>
										<xsl:text> Düzine</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode = 'MWH'">
									<span>
										<xsl:text> MEGAWATT SAAT (1000 kW.h)</xsl:text>
									</span>
								</xsl:when>
								<xsl:otherwise>
									<span>
										<xsl:value-of select="@unitCode"/>
									</span>
								</xsl:otherwise>
							</xsl:choose>
						</xsl:for-each>
					</xsl:if>
				</span>
			</td>
			<td>
				<span>
					<xsl:value-of
						select="format-number(./cac:Price/cbc:PriceAmount, '###.##0,########', 'european')"/>
					<xsl:if test="./cac:Price/cbc:PriceAmount/@currencyID">
						<xsl:text> </xsl:text>
						<xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode = 'TRY' or //n1:Invoice/cbc:DocumentCurrencyCode = 'TRL'">
							<xsl:text>TL</xsl:text>
						</xsl:if>
						<xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode != 'TRY' and //n1:Invoice/cbc:DocumentCurrencyCode != 'TRL'">
							<xsl:value-of select="./cac:Price/cbc:PriceAmount/@currencyID"/>
						</xsl:if>
					</xsl:if>
				</span>
			</td>
<xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:AllowanceCharge/cbc:MultiplierFactorNumeric and //n1:Invoice/cac:InvoiceLine/cac:AllowanceCharge/cbc:MultiplierFactorNumeric !=0">
				<td>
					<span>
						<xsl:text>&#160;</xsl:text>
						<xsl:for-each select="./cac:AllowanceCharge">
							<xsl:if test="./cbc:MultiplierFactorNumeric">
								<xsl:text> %</xsl:text>
								<xsl:value-of select="format-number(./cbc:MultiplierFactorNumeric * 100, '###.##0,00', 'european')"/><br/>
							</xsl:if>
						</xsl:for-each>
					</span>
				</td>
</xsl:if> 
<xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:AllowanceCharge">
				<td>
					<span>
						<xsl:for-each select="./cac:AllowanceCharge">
						<xsl:if test="./cbc:ChargeIndicator = 'true' and not(./cbc:Amount =0) ">(A)</xsl:if>
							<xsl:value-of
								select="format-number(./cbc:Amount, '###.##0,00', 'european')"
							/>
						<xsl:if test="./cbc:Amount/@currencyID">
							<xsl:text> </xsl:text>
							<xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode = 'TRY' or //n1:Invoice/cbc:DocumentCurrencyCode = 'TRL'">
								<xsl:text>TL</xsl:text>
							</xsl:if>
							<xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode != 'TRY' and //n1:Invoice/cbc:DocumentCurrencyCode != 'TRL'">
								<xsl:value-of select="./cbc:Amount/@currencyID"/>
							</xsl:if>
						</xsl:if><br/>
						</xsl:for-each>
					</span>
				</td>
</xsl:if> 
			<td>
				<span>
					<xsl:text>&#160;</xsl:text>
					<xsl:value-of
						select="format-number(./cbc:LineExtensionAmount, '###.##0,00', 'european')"/>
					<xsl:if test="./cbc:LineExtensionAmount/@currencyID">
						<xsl:text> </xsl:text>
						<xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode = 'TRY' or //n1:Invoice/cbc:DocumentCurrencyCode = 'TRL'">
							<xsl:text>TL</xsl:text>
						</xsl:if>
						<xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode != 'TRY' and //n1:Invoice/cbc:DocumentCurrencyCode != 'TRL'">
							<xsl:value-of select="./cbc:LineExtensionAmount/@currencyID"/>
						</xsl:if>
					</xsl:if>
				</span>
			</td>
<xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode ='0015'">
			<td>
				<span>
					<xsl:for-each
						select="./cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme">
						<xsl:if test="cbc:TaxTypeCode='0015' ">
							<xsl:text> </xsl:text>
							<xsl:if test="../../cbc:Percent">
								<xsl:text> %</xsl:text>
								<xsl:value-of
									select="format-number(../../cbc:Percent, '###.##0,00', 'european')"
								/>
							</xsl:if>
						</xsl:if>
					</xsl:for-each>
				</span>
			</td>
</xsl:if> 
<xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode ='0015'">
			<td>
				<span>
					<xsl:text>&#160;</xsl:text>
					<xsl:for-each
						select="./cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme">
						<xsl:if test="cbc:TaxTypeCode='0015' ">
							<xsl:text> </xsl:text>
							<xsl:value-of
								select="format-number(../../cbc:TaxAmount, '###.##0,00', 'european')"/>
							<xsl:if test="../../cbc:TaxAmount/@currencyID">
								<xsl:text> </xsl:text>
								<xsl:if test="../../cbc:TaxAmount/@currencyID = 'TRY' or ../../cbc:TaxAmount/@currencyID = 'TRL'">
									<xsl:text>TL</xsl:text>
								</xsl:if>
								<xsl:if test="../../cbc:TaxAmount/@currencyID != 'TRY' and ../../cbc:TaxAmount/@currencyID != 'TRL'">
									<xsl:value-of select="../../cbc:TaxAmount/@currencyID"/>
								</xsl:if>
							</xsl:if>
						</xsl:if>
					</xsl:for-each>
				</span>
			</td>
</xsl:if> 
<!-- <xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cbc:TaxExemptionReasonCode > 0"> -->
			
			<!-- <td style="font-size: xx-small;white-space:normal;"> -->
				<!-- <span> -->
					<!-- <xsl:for-each select="./cac:TaxTotal/cac:TaxSubtotal[./cac:TaxCategory/cbc:TaxExemptionReasonCode > '0']"> -->
					<!-- <xsl:if test="cac:TaxCategory/cbc:TaxExemptionReasonCode"> -->
					<!-- <xsl:value-of select="cac:TaxCategory/cbc:TaxExemptionReasonCode"/> - <xsl:value-of select="cac:TaxCategory/cbc:TaxExemptionReason"/> <br/><xsl:value-of select="cac:TaxCategory/cbc:Name"/><br/> -->
					<!-- </xsl:if> -->
					<!-- </xsl:for-each> -->
				<!-- </span> -->
			<!-- </td> -->
<!-- </xsl:if>  -->
<xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode !='0015' or //n1:Invoice/cac:InvoiceLine/cac:WithholdingTaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme">
			<td style="font-size:xx-small;">
				<div>
					<xsl:for-each
						select="./cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme">
						<xsl:if test="cbc:TaxTypeCode!='0015' ">
							<span class="is-long-{string-length(cbc:Name) > 15}">
							<xsl:text> </xsl:text>
							<xsl:if test="starts-with(cbc:TaxTypeCode,'4') or starts-with(cbc:TaxTypeCode,'6')">
								<xsl:value-of select="cbc:TaxTypeCode"/> -
							</xsl:if>
							<xsl:value-of select="cbc:Name"/>
								<xsl:if test="../../cbc:Percent">
									<xsl:text> (%</xsl:text>
									<xsl:value-of
										select="format-number(../../cbc:Percent, '###.##0,00', 'european')"
									/>
									<xsl:text>)=</xsl:text>
								</xsl:if>
							<xsl:value-of
								select="format-number(../../cbc:TaxAmount, '###.##0,00', 'european')"/>
							<xsl:if test="../../cbc:TaxAmount/@currencyID">
								<xsl:text> </xsl:text>
								<xsl:if test="../../cbc:TaxAmount/@currencyID = 'TRY' or ../../cbc:TaxAmount/@currencyID = 'TRL'">
									<xsl:text>TL</xsl:text>
								</xsl:if>
								<xsl:if test="../../cbc:TaxAmount/@currencyID != 'TRY' and ../../cbc:TaxAmount/@currencyID != 'TRL'">
									<xsl:value-of select="../../cbc:TaxAmount/@currencyID"/>
								</xsl:if>
							</xsl:if><br/>
							</span>
						</xsl:if>
					</xsl:for-each>

          			
					<xsl:for-each
						select="./cac:WithholdingTaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme">
						<xsl:if test="cbc:TaxTypeCode!='0015' ">
							<span class="is-long-{string-length(cbc:Name) > 15}"><xsl:if test="starts-with(cbc:TaxTypeCode,'4') or starts-with(cbc:TaxTypeCode,'6')">
								<xsl:value-of select="cbc:TaxTypeCode"/> -
							</xsl:if><xsl:value-of select="cbc:Name"/></span>
								<xsl:if test="../../cbc:Percent">
									<xsl:text> (%</xsl:text>
									<xsl:value-of
										select="format-number(../../cbc:Percent, '###.##0,00', 'european')"
									/>
									<xsl:text>)=</xsl:text>
								</xsl:if>
							<xsl:value-of
								select="format-number(../../cbc:TaxAmount, '###.##0,00', 'european')"/>
							<xsl:if test="../../cbc:TaxAmount/@currencyID">
								<xsl:text> </xsl:text>
								<xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode = 'TRY' or //n1:Invoice/cbc:DocumentCurrencyCode = 'TRL'">
									<xsl:text>TL</xsl:text>
								</xsl:if>
								<xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode != 'TRY' and //n1:Invoice/cbc:DocumentCurrencyCode != 'TRL'">
									<xsl:value-of select="../../cbc:TaxAmount/@currencyID"/>
								</xsl:if>
							</xsl:if>
						</xsl:if>
					</xsl:for-each>

				</div>
			</td>
</xsl:if> 

				</tr>
			</xsl:template>

	</xsl:stylesheet>
