import React from 'react';
import agent from '../../app/api/agent';
import { Form, Field } from 'react-final-form';
import { ITFN } from '../../app/models/tfn';
import toast from 'react-hot-toast';

async function onSubmit( { taxFileNumber }: any) {
  try {
    // validate tfn length
    if(taxFileNumber !== undefined)
    {
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
    else {
      toast.error(`Please enter a tax file number`);
    }
  } catch (error) {
    console.log(error);
  }
}

export default function TFNForm () {
    return (
        <Form 
            className="form-control"
            onSubmit={onSubmit}
            render={({ handleSubmit, form }) => (
                <form onSubmit={async event => {
                  await handleSubmit(event)
                  form.reset()
                }}>
                  <div>
                    <label className="control-label">Tax File Number</label>
                    <div className="divider-horizontal"/>
                    <Field
                      name="taxFileNumber"
                      component="input"
                      type="number"
                      placeholder="Tax File Number"
                    />
                  </div>
                  <div className="buttons">
                    <button className="btn btn-info" type="submit">
                      Submit
                    </button>
                    <div className="divider-horizontal"/>
                    <button
                      className="btn btn-danger"
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

