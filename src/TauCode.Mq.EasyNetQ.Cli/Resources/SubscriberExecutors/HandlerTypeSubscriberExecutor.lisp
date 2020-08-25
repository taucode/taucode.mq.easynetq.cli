(defblock :name get-subscriber-handler-type :is-top t
	(executor
		:executor-name get-subscriber-handler-type
		:verb "handler-type"
		:description "Gets handler type description by name or its part."
		:usage-samples (
			"sub type Foo.MyMessage"
			"sub type MyMes"
			"sub type 'MyMes'"))


	(some-text
		:classes term string
		:action argument
		:alias type-name
		:description "Type name, or part of type name."
		:doc-subst "type name")

	(end)
)
