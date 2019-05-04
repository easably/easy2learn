        <!-- Info Popup -->

            $(function() {
            	
                $('#activator').click(function(){
                    $('#content').animate({'margin-left':'-300px'},300,function(){});                        		
                    $('.logo_large').animate({'margin-left':'-160px'},300,function(){});                        		
                    $('.logo_medium').animate({'margin-left':'-160px'},300,function(){});                        		
                    $('.logo_small').animate({'margin-left':'-160px'},300,function(){});                        		
                    $('.icon_navigation').animate({'margin-left':'-200px'},300,function(){});  
                    $('#mobile_alert').animate({'margin-left':'-300px'},300,function(){});                        		
                		
                	$("#box").show();
                    $('#box').animate({'right':'0px'},300,function(){
                    });            
                });
                
                $('#boxclose').click(function(){
                    $('#content').animate({'margin-left':'-150px'},300,function(){});                        		
                    $('.logo_large').animate({'margin-left':'0px'},300,function(){});                        		
                    $('.logo_medium').animate({'margin-left':'0px'},300,function(){});                        		
                    $('.logo_small').animate({'margin-left':'0px'},300,function(){});                        		
                    $('.icon_navigation').animate({'margin-left':'-40px'},300,function(){});                        		
					$('#mobile_alert').animate({'margin-left':'0px'},300,function(){});
                   
                   $('#box').animate({'right':'-320px'},300,function(){  
                   $("#box").hide();
                   $(".info_small").show();  
                });
            });
        });

/* JavaScript code */

var is_touch_device = 'ontouchstart' in document.documentElement;
if(is_touch_device) 
	$("#hint").css("display","none");
if(is_touch_device) 	
	$("#scale_icon").css("display","none");
if(is_touch_device) 	
	$("#hint_touch").css("display","block");	

