function encryptmsg(msg){
  var p = 59;
  var q = 71;
  var n = p * q;
  var e = 97;
  var d = 293;
  var encryptedMsg = encrypt(msg, e, n);
  return encryptedMsg;
}

function decryptmsg(msg){
  var p = 59;
  var q = 71;
  var n = p * q;
  var e = 97;
  var d = 293;
  var decryptedMsg = decrypt(msg, d, n);
  return decryptedMsg;
}

function encrypt(msg, e, n){
  var charnr;
  var eCharnr;
  var cnt;
  var eStrFromInt;
  var eStrFromCnt;
  var eText = '';
  for (i = 0; i < msg.length; i++){
    //make each char an number with the ASCII Code Equivalents
    charnr = msg.charCodeAt(i);
    //encrypt the number
    eCharnr = new BigNumber(charnr);
    eCharnr = eCharnr.pow(e);
    eCharnr = eCharnr.mod(n);
    //if the ASCII Code Equivalent of the number is no normal string,
    // then change the number to a valid number
    cnt = 0;
    if(eCharnr > 126){
      while(eCharnr > 126){
        eCharnr = eCharnr - 126;
        cnt = cnt + 1;
      }
    }
    if(eCharnr < 32){
      eCharnr = parseInt(eCharnr);
      eCharnr = eCharnr + 223;//128;//223;
    }
    if(cnt < 32){
      cnt += 223;//128;//223;
    }
    //make the encrypted number a character with the ASCII Code Equivalents
    //and put it in a string
    eStrFromInt = String.fromCharCode(eCharnr);
    eStrFromCnt = String.fromCharCode(cnt);
    eText = eText + eStrFromInt + eStrFromCnt;
  }
  return eText;
}

function decrypt(msg, d, n){
  var charnr;
  var cnt;
  var dCharnr;
  var dStrFromInt;
  var dText = '';
  var cnt;
  //make each encrypted char an number with the ASCII Code Equivalents
  for (i = 0; i < msg.length; i += 2){
    charnr = msg.charCodeAt(i);
    cnt = msg.charCodeAt(i + 1);
    //if the number is not the original encrypted number,
    // then change it to the original
    if(charnr > 222){//128){//222){
      charnr -= 223;//128;//223;
    }
    if(cnt > 222){//128){//222){
      cnt -= 223;//128;//223;
    }
    charnr = charnr + cnt * 126;
    //decrypt the number
    //change the number to type BigNumber, because JS can't handle big numbers
    charnr = new BigNumber(charnr);
    dCharnr = charnr.pow(d);
    dCharnr = dCharnr.mod(n);
    //make the decrypted number a character with the ASCII Code Equivalents
    // and put it in a string
    dStrFromInt = String.fromCharCode(dCharnr);
    dText = dText + dStrFromInt;
  }
  return dText;
}

//check if value == prime number
function isprime(value) {
  var j = value;
  for (var i = 2; i < j; i++){
    if (j % i === 0){
      return 0;
    }
  }
  return 1;
}

//TEST
function rsa(){
  document.write("<br /><br />--Begin rsa<br />")
  //check if p and q are prime numbers
  var p = 59;//19;//257;
  var q = 71;//13;//337;
  var flag;
  flag = isprime(p);
  if(flag === 0){
    document.write("p is no prime number <br />")
    return;
  }
  flag = isprime(q);
  if(flag === 0){
    document.write("q is no prime number <br />")
    return;
  }

  //create variables n, phi, e, d and the message
  var n = p * q;
  var phi = (p - 1) * (q - 1);
  var e = 97;//7;//17;
  var d = 293;//31;//65777;
  var msg = "Dit is tekst dat ge-encrypt moet worden en gedecrypt";

  //call enrypt and decrypt functions
  var encryptedMsg = encrypt(msg, e, n);
  var decryptedMsg = decrypt(encryptedMsg, d, n);

  document.write("text = " + msg + "<br />")
  document.write("encrypted text = " + encryptedMsg + "<br />")
  document.write("decrypted text = " + decryptedMsg + "<br />")
  document.write("--end rsa<br />")
}
