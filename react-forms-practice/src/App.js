import { useState } from "react";
import "./App.css";

export default function App() {
  
  //TODO: Add your state fields here

     const [formData, setFormData] = useState({
        name: '',
        address: '',
        phone: '',
        email: '',
        complaint: '',
        contact: '',
        consent:false

    })

    const handleChange = (event) => {
      const { name, value, type } = event.target
  
      if (type === "checkbox") {
        
        setFormData({...formData, [name]: event.target.checked})
      }
      else{

        setFormData({
          ...formData,
          [event.target.name]: event.target.value
        })
      }
        
    }

    const handleSubmit = (event) => {
        event.preventDefault()
        
        console.log(formData)

        fetch('https://localhost:7298/complaints', {
          method: 'POST',
          body: JSON.stringify(formData), 
            /*JSON.stringify({
             title: title,
             body: body,
             userId: Math.random().toString(36).slice(2),
            
          }), */
          headers: {
             'Content-type': 'application/json; charset=UTF-8',
          },
       })
          .then((res) => console.log(res.json()))         
          .catch((err) => {
             console.log(err.message);
          });


    }


  return (
    <>
      <form className="form" onSubmit={handleSubmit}>
        <h2>Complaining form!</h2>
        <div className="form__section-left">
          <label>
            Full name
            <input type="text" name="name" onChange={handleChange} value={formData.name} required />
          </label>
          <label>
            Address
            <input type="text" name="address" onChange={handleChange} value={formData.address}/>
          </label>
          <label>
            Phone Number
            <input type="tel" name="phone" onChange={handleChange} value={formData.phone} />
          </label>

          <label>
            Email
            <input type="email" name="email" onChange={handleChange} value={formData.email}/>
          </label>
        </div>

        <div className="form__section-right">
          <label>
            Write your complaint
            <textarea
              name="complaint"
              rows="10"
              placeholder="You can complain here"
              value={formData.complaint}
              onChange={handleChange}

            
            ></textarea>
          </label>

          <div className="form__radio-group">
            <p>How do you want to be contacted? </p>
            <label>
              <input type="radio" name="contact" value="phone"  onChange={handleChange} checked={formData.contact=== "phone"}/>
              Phone
            </label>

            <label>
              <input type="radio" name="contact" value="email" onChange={handleChange} checked={formData.contact === "email"}/>
              Email
            </label>

            <label>
              <input type="radio" name="contact" value="post" onChange={handleChange} checked={formData.contact === "post"}/>
              Slow Mail
            </label>

            <label>
              <input type="radio" name="contact" value="none" onChange={handleChange} checked={formData.contact === "none"}/>
              No contact!
            </label>
          </div>

          <label>
            I agree you take my data, and do whatever
            <input type="checkbox" name="consent" id="consent" onChange={handleChange} checked={formData.consent} />
          </label>
        </div>
        <input type="submit" value="Submit!" />
      </form>
    </>
  );
}
