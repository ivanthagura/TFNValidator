import React from 'react';
import agent from '../../app/api/agent';
import { Form, Field } from 'react-final-form';
import { ITFN } from '../../app/models/tfn';
import toast from 'react-hot-toast';

async function onSubmit( { taxFileNumber }: any) {
  // validate tfn length
  if(taxFileNumber.length >=8  && taxFileNumber.length <= 9) {
    const tfn: ITFN = {tfnNumber : taxFileNumber};
    const { tfnIsValid } = await agent.TFN.validate(tfn);

    if(tfnIsValid) {
      toast.success(`${taxFileNumber} is a valid Tax file number`);
    }
    else {
      toast.error(`${taxFileNumber} is an invalid Tax file number`);
    }
  }
  else {
    toast.error(`Tax file number should contain 8 or 9 charachters`);
  }
}

export default function TFNForm () {
    return (
        <Form 
            onSubmit={onSubmit}
            render={({ handleSubmit, form }) => (
                <form onSubmit={handleSubmit}>
                  <div>
                    <label>Tax File Number</label>
                    <Field
                      name="taxFileNumber"
                      component="input"
                      type="number"
                      placeholder="Tax File Number"
                    />
                  </div>
                  <div className="buttons">
                    <button type="submit">
                      Submit
                    </button>
                    <button
                      type="button"
                      onClick={form.reset}
                    >
                      Reset
                    </button>
                  </div>
                </form>
              )}
        />
    );
}

