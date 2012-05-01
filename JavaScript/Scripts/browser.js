var document = {
    byid: {},
    nodeType: 9,
    getElementById: function(id){ return this.byid[id]; },
    getElementsByTagName: function(name){
      return this.body.getElementsByTagName(name);
    },
    addEventListener: function(){ },
    removeEventListener: function(){ },
    createElement: function(tag){
      return new fragment(tag);
    },
    createComment: function(){ return {} }    
  },
  window = this,
  navigator = { userAgent: 'Mozilla/5.0'};

function fragment (nodeName, nodeType){
        //if(this===window) return new fragment(nodeName);

        this.nodeName = (nodeName || 'none').toLowerCase(); 
        this.nodeType = nodeType || 1;
        this.style = {};
        this.attributes = {}; 
        this.className = '';

        this.childNodes = [];

        if(nodeName === 'a') {
            Object.defineProperty(this, 'href', { 
                get: function(){ return 'http://localhost/'; },
                set: function(val){ }
            });    
        } 

        var innerHTML = ''
        Object.defineProperty(this, 'innerHTML', { 
            get: function(){ return innerHTML; },
            set: function(val){ innerHTML = val; }
        });    
}

fragment.prototype = {
    createDocumentFragment: function(){ return new fragment('%fragment%', 11); },
    getElementsByTagName: function(name){ 
      name = (name || '').toLowerCase();
      return this.getall().filter(function(elm){ return elm.nodeName == name });
    },
    
    getElementsByClassName: function(name){
      return this.getall().filter(function(elm){ return (elm.className||'').split(' ').indexOf(name) > -1; });
    },

    appendChild: function(child){  
      if(child.parentNode){
        child.parentNode.removeChild(child);
      }

      child.parentNode = this;
      this.childNodes.push(child);
    },

    cloneNode: function(deep){
        var other = new fragment(this.nodeName, this.nodeType);
        this.childNodes.forEach(function(child){
            other.appendChild(child.cloneNode(deep));
        });
    },
    
    insertBefore: function(newchild, child){ 
      var i = this.childNodes.indexOf(child);
      if(i>-1) {
        this.childNodes.splice(i, 0, child);
        newchild.parentNode = this;
      } else this.appendChild(newchild);
    },

    removeChild: function(child) {
      if(!child) return;
      var i = this.childNodes.indexOf(child);
      if(i>-1) {
        this.childNodes.splice(i, 1);
        child.parentNode = undefined;
      }
    },

    setAttribute: function(name, value){
      this.attributes[name] = value;
    },
    
    getAttribute: function(name){
      return this.attributes[name];
    },

    getall: function() {
      var ret = [this];
      this.childNodes.forEach(function(child){
        if(child.getall) ret.push.apply(ret, child.getall());
      });     
      return ret;
    },
     
    get lastChild(){
        return this.childNodes[this.childNodes.length - 1];
    },

    get firstChild(){
        return this.childNodes[0];
    },

    get id(){
        return this.getAttribute('id');
    }, 
    set id(value){        
        this.setAttribute('id', value);
        document.byid[value] = this;
    }, 
    
    get rel(){
        return this.getAttribute('rel');
    }, 
    set rel(value){        
        this.setAttribute('rel', value); 
    }, 
    
    get className(){
        return this.getAttribute('className');
    }, 
    set className(value){        
        this.setAttribute('className', value); 
    }            
}

document.documentElement = document.body = new fragment('body');
window.document = document; 
window.addEventListener = function(){ }
 