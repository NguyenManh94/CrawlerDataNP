var s = document.getElementsByClassName('name');
var k = document.getElementById('t');
var x = s[0].outerHTML;


var t = document.getElementById('show-adv');
var v = t.getElementsByTagName('p');
v[0].parentNode.removeChild(v[0]);

var vv = t.getElementsByTagName('div');
vv[0].parentNode.removeChild(vv[0]);


var z = document.getElementsByClassName('post-container');
var k = z[0].firstChild
k.parentNode.removeChild(k);