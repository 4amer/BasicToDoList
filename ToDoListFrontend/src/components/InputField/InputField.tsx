import Style from "./InputField.module.css";

const InputField = () => {
  return (
    <div className={"input-group mb-3 " + Style["bottom-component"]}>
      <input
        type="text"
        className="form-control"
        placeholder="Recipient’s username"
        aria-label="Recipient’s username"
        aria-describedby="button-addon2"
      />
      <button
        className="btn btn-outline-secondary"
        type="button"
        id="button-addon2"
      >
        Button
      </button>
    </div>
  );
};

export default InputField;
