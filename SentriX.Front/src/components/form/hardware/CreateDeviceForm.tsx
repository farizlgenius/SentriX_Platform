import { ChangeEvent, PropsWithChildren, useEffect, useState } from "react";
import Label from "../Label.tsx";
import Input from "../input/InputField.tsx";
import Button from "../../ui/button/Button.tsx";
import { FormProp, FormType } from "../../../model/Form/FormProp.ts";
import { Options } from "../../../model/Options.ts";
import { send } from "../../../api/api.ts";
import { DeviceEndpoint } from "../../../endpoint/HardwareEndpoint.ts";
import { ModeDto } from "../../../model/ModeDto.ts";
import { CreateDeviceDto } from "../../../model/Device/CreateDeviceDto.ts";







const CreateDeviceForm: React.FC<PropsWithChildren<FormProp<CreateDeviceDto>>> = ({ dto, type, handleClick, setDto }) => {
      const [deviceOptions, setDeviceOptions] = useState<Options[]>([])
      const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
            setDto(prev => ({ ...prev, [e.target.name]: e.target.value }));
      }

      const fetchType = async () => {
            const res = await send.get(DeviceEndpoint.TYPE);
            if (res && res.data.data) {
                  res.data.data.map((a: ModeDto) => {
                        setDeviceOptions(prev => ([...prev, {
                              label: a.name,
                              value: a.value,
                              description: a.description
                        }]))
                  })

            }
      }


      useEffect(() => {
            fetchType();
      }, [])

      return (
            <>


                  <div className="w-full flex justify-center">
                        <div className="w-full max-w-4xl bg-white dark:bg-gray-900 rounded-2xl shadow-sm">

                              {/* Form */}
                              <div className="p-8">
                                    <div className="grid grid-cols-1 md:grid-cols-2 gap-x-10 gap-y-6">

                                          <div className="space-y-2">
                                                <Label htmlFor="name">Name</Label>
                                                <Input
                                                      disabled={type == FormType.INFO}
                                                      name="name"
                                                      value={dto.name}
                                                      type="text"
                                                      id="name"
                                                      onChange={handleChange}
                                                />
                                          </div>

                                          <div className="space-y-2">
                                                <Label htmlFor="driverId">Component Id</Label>
                                                <Input
                                                      
                                                      name="driverId"
                                                      value={dto.componentId}
                                                      id="driverId"
                                                      onChange={handleChange}
                                                      isReadOnly
                                                />
                                          </div>

                                          <div className="space-y-2">
                                                <Label htmlFor="mac">MAC Address</Label>
                                                <Input name="mac" value={dto.mac} id="mac" isReadOnly />
                                          </div>

                                          {/* <div className="space-y-2">
                                                <Label htmlFor="ipAddress">IP Address</Label>
                                                <Input disabled name="ip" value={dto.ip} id="ipAddress" isReadOnly />
                                          </div> */}

                                          <div className="space-y-2">
                                                <Label htmlFor="firmware">Firmware</Label>
                                                <Input value={dto.fw} id="firmware" isReadOnly />
                                          </div>

                                          {/* <div className="space-y-2">
                                                <Label htmlFor="port">Port</Label>
                                                <Input disabled value={dto.port} id="port" isReadOnly />
                                          </div> */}

                                          <div className="space-y-2">
                                                <Label htmlFor="serialnumber">Serial Number</Label>
                                                <Input value={dto.serialNumber} id="serialnumber" isReadOnly />
                                          </div>

                                          <div className="space-y-2">
                                                <Label htmlFor="model">Device Type</Label>
                                                <Input value={dto.type} id="model"  isReadOnly />
                                          </div>

                                    </div>

                                    {/* Buttons */}
                                    <div className="flex justify-end gap-4 mt-10 pt-6 border-t border-gray-200 dark:border-gray-800">
                                          <Button
                                                onClickWithEvent={handleClick}
                                                disabled={type == FormType.INFO}
                                                name={type == FormType.UPDATE ? "update" : "create"}
                                                className="w-40"
                                                size="sm"
                                          >
                                                {type == FormType.UPDATE ? "Update" : "Create"}
                                          </Button>

                                          <Button
                                                onClickWithEvent={handleClick}
                                                name="close"
                                                variant="danger"
                                                className="w-40"
                                                size="sm"
                                          >
                                                Cancel
                                          </Button>
                                    </div>

                              </div>
                        </div>
                  </div>





            </>);
}

export default CreateDeviceForm;