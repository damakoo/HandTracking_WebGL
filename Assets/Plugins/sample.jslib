mergeInto(LibraryManager.library, {
    Hello: function(){
        window.alert("Hello, world!");
    },
    Predict: function(base64Text) {
        base64Text = Pointer_stringify(base64Text);
        tf_predict(base64Text)
    },
    Result: function(){
    showresult();
    },
 GetLocalStorage: function(key) {
    var item_string = localStorage.getItem(Pointer_stringify(key));
 
    if (!item_string) {
      return "";
    }
 
    var bufferSize = lengthBytesUTF8(item_string) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(item_string, buffer, bufferSize);
    return buffer;
  },
 
  SetLocalStorage: function(key, user_id) {
    localStorage.setItem(Pointer_stringify(key), Pointer_stringify(user_id));
  }
});