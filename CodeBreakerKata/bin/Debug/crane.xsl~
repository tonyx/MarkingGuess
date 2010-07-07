<?xml version="1.0" encoding="US-ASCII"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                version="1.0">

<!--
     Creates an XPath reference report from an arbitrary XML instance.

     $Id: Crane-xml2xpath.xsl,v 1.1 2006/12/04 15:04:31 G. Ken Holman Exp $

     Implementation note:  Saxon does not require the redundant use of 
                           xml:space below, but MSXML does

Copyright (C) - Crane Softwrights Ltd. 
              - http://www.CraneSoftwrights.com/links/res-dev.htm

Redistribution and use in source and binary forms, with or without 
modification, are permitted provided that the following conditions are met:

- Redistributions of source code must retain the above copyright notice, 
  this list of conditions and the following disclaimer. 
- Redistributions in binary form must reproduce the above copyright notice, 
  this list of conditions and the following disclaimer in the documentation 
  and/or other materials provided with the distribution. 
- The name of the author may not be used to endorse or promote products 
  derived from this software without specific prior written permission. 

THIS SOFTWARE IS PROVIDED BY THE AUTHOR ``AS IS'' AND ANY EXPRESS OR 
IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES 
OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN 
NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, 
SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED 
TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR 
PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF 
LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING 
NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, 
EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

Note: for your reference, the above is the "Modified BSD license", this text
      was obtained 2002-12-16 at http://www.xfree86.org/3.3.6/COPYRIGHT2.html#5
-->

<!--producing a simple text report-->
<xsl:output method="text"/>

<!--act on every elment-->
<xsl:template match="*">
  <xsl:variable name="ordinal">
    <!--where are we in the instance?-->
    <xsl:number count="*" level="any"/>
  </xsl:variable>
  <!--report location-->
  <xsl:variable name="element">
    <xsl:for-each select="ancestor-or-self::*">
      <xsl:text/>/<xsl:value-of select="name(.)"/>
      <xsl:if test="preceding-sibling::*[name(.)=name(current())]">
        <!--not the first!-->
        <xsl:text/>[<xsl:number/>]<xsl:text/>
      </xsl:if>
    </xsl:for-each>
  </xsl:variable>
  <xsl:text/>!<xsl:value-of select="$ordinal"/>!   <xsl:text/>
  <xsl:value-of select="$element"/><xsl:text xml:space="preserve">
</xsl:text>
  <!--report all attributes-->
  <xsl:for-each select="@*">
    <xsl:sort select="name(.)"/>
    <xsl:value-of select="concat('!',$ordinal,'.',position(),'! ',
                                 $element,'/@',name(.))"/>
    <xsl:text xml:space="preserve">
</xsl:text>
  </xsl:for-each>
  <!--process all children-->
  <xsl:apply-templates select="*"/>
</xsl:template>

</xsl:stylesheet>

