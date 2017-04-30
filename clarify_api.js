var Clarifai = require('clarifai');

// instantiate a new Clarifai app passing in your clientId and clientSecret
// first parameter: client id
// second paramter: client secret
var app = new Clarifai.App(
  'S6wCX8lrJwAnEiU20ZNaMpwRp8m9qAjdR3mrqLkj',
  'Sq5SP0oaW1ReoFcnpb55hQUU03_EhRXMdlQ0nn3r'
);

// predict the contents of an image by passing in a url
// first parameter: model name (should not have spaces)
// second parameter: url of image you want to identify
app.models.predict("gas_genie", "https://www.allianceonline.co.uk/product_images/DPP01752.jpg").then(
  function(response) {
    //returns the concept with the highest probability
    console.log(response.outputs[0].data.concepts[0]);
  },
  function(err) {
    console.error(err);
  }
);
