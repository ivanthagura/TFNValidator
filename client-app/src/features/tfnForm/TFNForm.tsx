import React from 'react';
import agent from '../../app/api/agent';
import { Form, Field } from 'react-final-form';
import { ITFN } from '../../app/models/tfn';

const sleep = (ms: number) => new Promise(resolve => setTimeout(resolve, ms))

async function onSubmit(values: any) {
    await sleep(300)

    const { taxFileNumber } = values;
    const tfn: ITFN = {tfnNumber : taxFileNumber};
    const response = await agent.TFN.validate(tfn);

    window.alert(response);
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
                      type="text"
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

